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

                            // Parse the JSON data into a Task object
                            var task = JsonConvert.DeserializeObject<Task>(requestBody);
                            taskColntroller.AddTask(task);

                            // Respond with a success status code and the added task
                            response.StatusCode = 200; // OK
                            response.AsText("Task added successfully!");
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

            Route.Add("/tasks", (request, response, props) =>
            {
                response.AsText("Hello World");
            });
            // add a post method which receives a task
            HttpServer.ListenAsync(1337, CancellationToken.None, Route.OnHttpRequestAsync).Wait();
        }
    }
}
