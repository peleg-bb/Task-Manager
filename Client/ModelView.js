// Get references to HTML elements
import { addTaskToServer, fetchTaskListFromServer } from './ClientRequests.js';
const taskForm = document.getElementById('task-form');
const taskTitleInput = document.getElementById('task-title');
const taskDescriptionInput = document.getElementById('task-description');
const taskList = document.getElementById('task-list');

// Wait for the HTML document to be fully loaded
// document.addEventListener('DOMContentLoaded', function() {
//     // Call the function to fetch the initial task list from the server
//     fetchTaskListFromServer();
// });

// Function to add a new task
// function addTask(title, description) {
//     // Create a new list item
//     const listItem = document.createElement('li');
//
//     // Create a task object to hold title and description
//     const task = { title, description };
//
//     // Set the text content of the list item
//     listItem.textContent = `Title: ${task.title}, Description: ${task.description}`;
//
//     // Append the list item to the task list
//     taskList.appendChild(listItem);
// }
// export function addTask(id, title, description, status) {
//     // Create a new list item
//     const listItem = document.createElement('li');
//
//     // Create a task object to hold title and description
//     const task = { id, title, description, status };
//
//     // Set the text content of the list item
//     listItem.textContent = `ID: ${task.id}, Title: ${task.title}, Description: ${task.description}, Status: ${task.status}`;
//
//     // Append the list item to the task list
//     taskList.appendChild(listItem);
// }

// Event listener for form submission
taskForm.addEventListener('submit', function (e) {
    e.preventDefault(); // Prevent the default form submission behavior
    const title = taskTitleInput.value.trim(); // Get the task title
    const description = taskDescriptionInput.value.trim(); // Get the task description
    console.log(title, description);

    if (title !== '' && description !== '') {
        addTask(title, description, "To Do"); // Add the task to the UI "To Do" list
        addTaskToServer(title, description); // Add the task to the server
        taskTitleInput.value = ''; // Clear the title input field
        taskDescriptionInput.value = ''; // Clear the description input field
    }
});
export function addTask(title, description, status) {
    // Create a new list item
    const listItem = document.createElement('li');

    // Create a task object to hold title and description
    const task = {title, description, status };

    // Set the text content of the list item
    listItem.textContent = `Title: ${task.title}, Description: ${task.description}, Status: ${task.status}`;

    // Append the list item to the task list
    taskList.appendChild(listItem);
}
