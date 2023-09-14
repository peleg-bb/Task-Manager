
export function fetchTaskListFromServer() {
    // Define the URL of your C# backend endpoint for retrieving the task list
    const url = 'http://localhost:1337/api/tasks';

    // Send a GET request to the server
    fetch(url, {mode: 'no-cors'})
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
export function addTaskToServer(title, description) {
    // Create a task object with title and description
    const task = { title, description };

    // Define the URL of your C# backend endpoint for adding tasks
    const url = 'http://localhost:1337/api/tasks/add';
    const requestBody = JSON.stringify(task)
    // Send a POST request to the server
    fetch(url, {mode: 'no-cors',
        method: 'POST',
        body: requestBody,
        headers: {
            'Content-Type': 'application/json',
        }// Convert the task object to JSON
    }).then(response => {
        if (!response.ok) {
            console.log(response);
        }
        // Parse the response JSON to get the task ID
        return response.json();
    })
        .then(data => {
            console.log('Task added:', data);
        })
        .catch(error => {
            // Handle errors (e.g., network error, invalid response)
            console.error('Error adding task:', error);
        });
}
