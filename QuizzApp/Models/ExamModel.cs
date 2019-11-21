using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizzApp.Models
{
    public class ExamModel
    {
        public int QustionId { get; set; }
        public int SelectedOption { get; set; }
        public string QustionText { get; set; }
        public List<ExamOptions> options { get; set; }
    }

    public class ExamOptions
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        
    }


}