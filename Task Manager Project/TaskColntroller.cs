using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_Project
{
    
    internal class TaskColntroller
    {
        private HashSet<Task> tasks;
        public TaskColntroller()
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

        public bool CompleteTask(int taskID)
        {
            foreach (Task task in tasks)
            {
                if (taskID == task.id)
                {
                    task.status = Task.TaskStatus.Done;
                    return true;
                }
            }

            return false;
        }



    }
}
