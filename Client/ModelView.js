// Get references to HTML elements
import { addTaskToServer, fetchTaskListFromServer, completeTaskOnServer } from './ClientRequests.js';
const taskForm = document.getElementById('task-form');
const taskTitleInput = document.getElementById('task-title');
const taskDescriptionInput = document.getElementById('task-description');
const taskList = document.getElementById('task-list');

// Wait for the HTML document to be fully loaded
// document.addEventListener('DOMContentLoaded', function() {
//     // Call the function to fetch the initial task list from the server
//     fetchTaskListFromServer();
// });

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
// export function addTask(title, description, status) {
//     // Create a new list item
//     const listItem = document.createElement('li');
//
//     // Create a task object to hold title and description
//     const task = {title, description, status };
//
//     // Set the text content of the list item
//     listItem.textContent = `Title: ${task.title}, Description: ${task.description}, Status: ${task.status}`;
//
//     // Append the list item to the task list
//     taskList.appendChild(listItem);
// }
export function addTask(title, description, status) {
    // Create a new list item
    const listItem = document.createElement('li');

    // Create a task object to hold title, description, and status
    const task = { title, description, status };

    // Set the text content of the list item to display task information
    listItem.textContent = `Title: ${task.title}, Description: ${task.description}, Status: ${task.status}`;

    // Create a "Complete Task" button
    const completeButton = document.createElement('button');
    completeButton.textContent = 'Complete Task';

    // Add a click event listener to the button
    completeButton.addEventListener('click', () => {
        // Handle the task completion here
        // You can update the task's status or perform other actions
        // For now, let's remove the task when the button is clicked
        listItem.textContent = `Title: ${task.title}, Description: ${task.description}, Status: Completed`;
        completeTaskOnServer(task.title)
    });

    // Append the "Complete Task" button to the list item
    listItem.appendChild(completeButton);

    // Append the list item to the task list
    taskList.appendChild(listItem);
}
