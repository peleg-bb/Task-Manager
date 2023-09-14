using Newtonsoft.Json;

namespace Task_Manager_Project
{
    /// <summary>
    /// This class represents a task.
    /// A task is identified by an id, has a title, a description and a status: {InProgress, Done}
    /// </summary>
    internal class Task
    {
        [JsonProperty("id")]
        internal int id { get; set; }
        [JsonProperty("title")]
        internal string title { get; set; }
        [JsonProperty("description")]
        internal string description { get; set; }
        [JsonProperty("status")]
        internal TaskStatus status { get; set; }

        internal enum TaskStatus { InProgress, Done };
        /// <summary>
        /// Constructor to be called the TaskController
        /// </summary>
        public Task(int id, string title, string description)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.status = TaskStatus.InProgress;
        }
        /// <summary>
        /// A parameterless constructor for the JSON deserialisation
        /// </summary>
        public Task(){}
        
    }
}
