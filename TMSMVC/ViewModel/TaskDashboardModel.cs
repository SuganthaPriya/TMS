using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSMVC.ViewModel
{
    public class TaskDashboardModel
    {
        public int TaskID { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        public string AssignerFirstName { get; set; }

        public string AssignerLastName { get; set; }

        public string AssigneeFirstName { get; set; }

        public string AssigneeLastName { get; set; }

        public DateTime AssignedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        public string TaskStatusStatusName { get; set; }

        public string TaskPriorityPriorityName { get; set; }
    }
}