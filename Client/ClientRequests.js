/**
 * Fetches the task list from the server.
 */
export function fetchTaskListFromServer() {
    const url = 'http://localhost:1337/api/tasks';

    fetch(url, { mode: 'no-cors' })
        .then(response => response.json())
        .then(data => {
            console.log('Task list retrieved:', data);
        })
        .catch(error => {
            // console.error('Error retrieving task list:', error);
        });
}

/**
 * Adds a new task to the server.
 * @param {string} title - The title of the task.
 * @param {string} description - The description of the task.
 */
export function addTaskToServer(title, description) {
    const task = { title, description };
    const url = 'http://localhost:1337/api/tasks/add';
    const requestBody = JSON.stringify(task);

    fetch(url, {
        mode: 'no-cors',
        method: 'POST',
        body: requestBody,
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => {
            if (!response.ok) {
                console.log(response);
            }
            return response.json();
        })
        .then(data => {
            console.log('Task added:', data);
        })
        .catch(error => {
            // console.error('Error adding task:', error);
        });
}

/**
 * Marks a task as completed on the server.
 * @param {string} taskTitle - The title of the task to mark as completed.
 */
export function completeTaskOnServer(taskTitle) {
    const url = 'http://localhost:1337/api/tasks/complete';
    const requestBody = JSON.stringify(taskTitle);

    fetch(url, {
        mode: 'no-cors',
        method: 'POST',
        body: requestBody,
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => {
            if (!response.ok) {
                console.log(response);
            }
            return response.json();
        })
        .then(data => {
            console.log('Task completed:', data);
        })
        .catch(error => {
            // console.error('Error completing task:', error);
        });
}
