
function fetchTaskListFromServer() {
    // Define the URL of your C# backend endpoint for retrieving the task list
    const url = 'http://localhost:1337/api/tasks';

    // Send a GET request to the server
    fetch(url)
        .then(response => response.json())
        .then(data => {
            // Handle the response from the server (e.g., display the task list)
            console.log('Task list retrieved:', data);
            // You can update your UI with the retrieved task list
        })
        .catch(error => {
            // Handle errors (e.g., network error, invalid response)
            console.error('Error retrieving task list:', error);
        });
}
function addTaskToServer(title, description) {
    // Create a task object with title and description
    const task = { title, description };

    // Define the URL of your C# backend endpoint for adding tasks
    const url = 'http://localhost:1337/api/tasks/add';

    // Send a POST request to the server
    fetch(url, {
        method: 'POST',
        body: JSON.stringify(task), // Convert the task object to JSON
    })
        .then(response => response.json())
        .then(data => {
            // Handle the response from the server (e.g., display the added task)
            console.log('Task added:', data);
            // You can update your UI or perform other actions as needed
            data.forEach(task => {
                addTask(task.id, task.title, task.description, task.status);
            });
        })
        .catch(error => {
            // Handle errors (e.g., network error, invalid response)
            console.error('Error adding task:', error);
        });
}