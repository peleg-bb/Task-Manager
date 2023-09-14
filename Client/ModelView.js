import { addTaskToServer, fetchTaskListFromServer, completeTaskOnServer } from './ClientRequests.js';
const taskForm = document.getElementById('task-form');
const taskTitleInput = document.getElementById('task-title');
const taskDescriptionInput = document.getElementById('task-description');
const taskList = document.getElementById('task-list');

taskForm.addEventListener('submit', function (e) {
    e.preventDefault();
    const title = taskTitleInput.value.trim();
    const description = taskDescriptionInput.value.trim();

    if (title !== '' && description !== '') {
        addTask(title, description, "To Do");
        addTaskToServer(title, description);
        taskTitleInput.value = '';
        taskDescriptionInput.value = '';
    }
});

/**
 * Adds a new task to the UI and sends it to the server.
 * @param {string} title - The title of the task.
 * @param {string} description - The description of the task.
 * @param {string} status - The status of the task (e.g., "To Do").
 */
export function addTask(title, description, status) {
    const listItem = document.createElement('li');
    const task = { title, description, status };
    listItem.textContent = `Title: ${task.title}, Description: ${task.description}, Status: ${task.status}`;

    // Create a "Complete Task" button
    const completeButton = document.createElement('button');
    completeButton.textContent = 'Complete Task';
    completeButton.classList.add('complete-button');
    completeButton.addEventListener('click', () => {
        listItem.textContent = `Title: ${task.title}, Description: ${task.description}, Status: Completed`;
        completeTaskOnServer(task.title);
    });

    listItem.appendChild(completeButton);
    taskList.appendChild(listItem);
}
