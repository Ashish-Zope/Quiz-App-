using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizzApp.Models
{
    public class ReviewAnswersModel
    {
        public int QustionId { get; set; }
        public string QustionText { get; set; }
        public int ? SelectedAnswerId { get; set; }
        public List<ReviewAnswersOption> Options { get; set; }
    }

    public class ReviewAnswersOption 
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public bool IsAnswer { get; set; }

    }

}