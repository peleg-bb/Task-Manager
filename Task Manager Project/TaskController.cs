using System.Collections.Generic;
using System.Linq;

namespace Task_Manager_Project
{
    /// <summary>
    /// This class is responsible for managing the tasks.
    /// It has a list of tasks and methods to add and complete tasks.
    /// </summary>
    internal class TaskController
    {
        private HashSet<Task> tasks;
        public TaskController()
        {
            tasks = new HashSet<Task>();
        }
        public Task AddTask(Task task)
        {
            task.id = tasks.Count + 1;
            task.status = Task.TaskStatus.InProgress;
            tasks.Add(task);
            return task;
        }
        
        public List<Task> GetTasks()
        {
            return tasks.ToList();
        }

        /// <summary>
        /// This method completes a task by changing its status to Done
        /// Returns true if the task was found and completed, false otherwise
        /// </summary>
        public bool CompleteTask(string taskTitle)
        {
            foreach (Task task in tasks)
            {
                if (taskTitle == task.title)
                {
                    task.status = Task.TaskStatus.Done;
                    return true;
                }
            }

            return false;
        }



    }
}
