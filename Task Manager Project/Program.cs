using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleHttp;
using Newtonsoft.Json;
using System.IO;

namespace Task_Manager_Project
{
    internal class Program
    {

        static void Main(string[] args)
        {
            TaskController taskController = new TaskController();
            Route.Add("/api/tasks/add", (request, response, props) =>
            {
                if (request.HttpMethod == "POST")
                {
                    try
                    {
                        // Read the request body data
                        using (var reader = new StreamReader(request.InputStream))
                        {
                            var requestBody = reader.ReadToEnd();
                            response.Headers.Add("Content-Type", "application/json");
                            var taskToAdd = JsonConvert.DeserializeObject<Task>(requestBody);
                            Task taskAdded = taskController.AddTask(taskToAdd);

                            response.StatusCode = 200; // OK
                            string responseJson = JsonConvert.SerializeObject(taskAdded);
                            response.OutputStream.Write(Encoding.UTF8.GetBytes(responseJson), 0, responseJson.Length);
                            response.OutputStream.Close();


                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle errors (e.g., invalid JSON)
                        response.StatusCode = 400; // Bad Request
                        response.AsText($"Error: {ex.Message}");
                    }
                }

                else
                {
                    // Handle other HTTP methods for this route
                    response.StatusCode = 405; // Method Not Allowed
                    response.AsText("Method not allowed for this route.");
                }
            }, method:"POST");

            Route.Add("/api/tasks/complete", (request, response, props) =>
            {
                if (request.HttpMethod == "POST")
                {
                    try
                    {
                        using (var reader = new StreamReader(request.InputStream))
                        {
                            var requestBody = reader.ReadToEnd();

                            // Parse the JSON data into a Task object
                            var taskID = JsonConvert.DeserializeObject<string>(requestBody);

                            if (taskController.CompleteTask(taskID))
                            {
                                response.StatusCode = 200; // OK
                                response.AsText("Task successfully marked as complete!");
                            }
                            else
                            {
                                response.StatusCode = 400;
                                response.AsText("Task ID not found");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle errors (e.g., invalid JSON)
                        response.StatusCode = 400; // Bad Request
                        response.AsText($"Error: {ex.Message}");
                    }
                }

                else
                {
                    // Handle other HTTP methods for this route
                    response.StatusCode = 405; // Method Not Allowed
                    response.AsText("Method not allowed for this route.");
                }
            }, method: "POST");

            Route.Add("/api/tasks", (request, response, props) =>
            {
                List<Task> tasks = taskController.GetTasks();
                response.StatusCode = 200;
                response.Headers.Add("Content-Type", "application/json");

                string tasksJson = JsonConvert.SerializeObject(tasks);
                response.AsText(tasksJson);
            });
            
            HttpServer.ListenAsync(1337, CancellationToken.None, Route.OnHttpRequestAsync).Wait();
        }
    }
}
