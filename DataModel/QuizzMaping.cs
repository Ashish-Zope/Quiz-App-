//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuizzMaping
    {
        public QuizzMaping()
        {
            this.QuizzQustionMapings = new HashSet<QuizzQustionMaping>();
        }
    
        public int Qm_Id { get; set; }
        public int Qm_QuizzSubjectId { get; set; }
        public int Qm_QuizzLvlId { get; set; }
        public string Qm_Description { get; set; }
    
        public virtual QuizzLevel QuizzLevel { get; set; }
        public virtual QuizzSubject QuizzSubject { get; set; }
        public virtual ICollection<QuizzQustionMaping> QuizzQustionMapings { get; set; }
    }
}
