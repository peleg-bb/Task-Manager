using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task_Manager_Project
{
    internal class Task
    {
        internal int id { get; set; }
        [JsonProperty("title")]
        internal string title { get; set; }
        [JsonProperty("description")]
        internal string description { get; set; }
        internal TaskStatus status { get; set; }

        internal enum TaskStatus { InProgress, Done };
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
