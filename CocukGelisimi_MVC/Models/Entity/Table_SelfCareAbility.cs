//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CocukGelisimi_MVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_SelfCareAbility
    {
        public short SelfCareAbilityID { get; set; }
        public short StudentID { get; set; }
        public string StudentFullName { get; set; }
        public Nullable<short> EvaluationYear { get; set; }
        public string EvaluationPeriod { get; set; }
        public string EvaluationSt { get; set; }
        public string Kazanım1 { get; set; }
        public string Kazanım2 { get; set; }
        public string Kazanım3 { get; set; }
        public string Kazanım4 { get; set; }
        public string Kazanım5 { get; set; }
        public string Kazanım6 { get; set; }
        public string Kazanım7 { get; set; }
        public string Kazanım8 { get; set; }
        public string MySuggestion { get; set; }
    
        public virtual Table_Student Table_Student { get; set; }
    }
}
