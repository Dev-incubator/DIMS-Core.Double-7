﻿using System;
using System.Collections.Generic;

namespace DIMS_Core.BusinessLayer.Models
{
    public class TaskModel
    {
        public TaskModel()
        {
            UserTasks = new HashSet<UserTaskModel>();
        }

        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadlineDate { get; set; }

        public ICollection<UserTaskModel> UserTasks { get; set; }
    }
}