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
    
    public partial class QuizzQustionMaping
    {
        public QuizzQustionMaping()
        {
            this.CandidateRepositories = new HashSet<CandidateRepository>();
        }
    
        public int Qm_Id { get; set; }
        public Nullable<int> Qm_QuizzID { get; set; }
        public Nullable<int> Qm_QutionID { get; set; }
        public Nullable<int> Qm_OptionId { get; set; }
        public Nullable<bool> Qm_IsAnswer { get; set; }
    
        public virtual ICollection<CandidateRepository> CandidateRepositories { get; set; }
        public virtual QuizzMaping QuizzMaping { get; set; }
        public virtual QuizzQuestionMaster QuizzQuestionMaster { get; set; }
        public virtual QuizzQustionsOption QuizzQustionsOption { get; set; }
    }
}
