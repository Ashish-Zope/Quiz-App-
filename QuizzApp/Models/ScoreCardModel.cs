using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizzApp.Models
{
    public class ScoreCardModel
    {
        public int QustionId { get; set; }
        public string QustionText { get; set; }
        public int SelectedAnswerId { get; set; }
        public bool IsAnswer { get; set; }
        public int CorrectAnswerId { get; set; }
    }

    public class ScoreCardOption 
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
    }

}