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
            TaskColntroller taskColntroller = new TaskColntroller();
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
                            // Parse the JSON data into a Task object
                            var taskToAdd = JsonConvert.DeserializeObject<Task>(requestBody);
                            Task taskAdded = taskColntroller.AddTask(taskToAdd);

                            // Respond with a success status code and the added task
                            response.StatusCode = 200; // OK
                            // return a json with task Id 
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
                        // Read the request body data
                        using (var reader = new StreamReader(request.InputStream))
                        {
                            var requestBody = reader.ReadToEnd();

                            // Parse the JSON data into a Task object
                            var taskID = JsonConvert.DeserializeObject<string>(requestBody);

                            if (taskColntroller.CompleteTask(taskID))
                            {
                                // Respond with a success status code and the added task
                                response.StatusCode = 200; // OK
                                // return a json with task Id 
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
                List<Task> tasks = taskColntroller.GetTasks();
                response.StatusCode = 200;
                response.Headers.Add("Content-Type", "application/json");

                // Serialize and send the task list as JSON
                string tasksJson = JsonConvert.SerializeObject(tasks);
                // response.OutputStream.Write(Encoding.UTF8.GetBytes(tasksJson), 0, tasksJson.Length);
                response.AsText(tasksJson);
            });
            // add a post method which receives a task
            HttpServer.ListenAsync(1337, CancellationToken.None, Route.OnHttpRequestAsync).Wait();
        }
    }
}
