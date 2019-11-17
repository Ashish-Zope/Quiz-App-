using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizzApp.Models
{
    public class SelectExamModel
    {
        public string Description { get; set; }

       // public string ExamLevelRedioBtn { get; set; }
        public int ExamID { get; set; }
        
        public int ExamLevelId { get; set; }

        public string ExamLevel { get; set; }
    }

}