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
    
    public partial class Table_G_Information
    {
        public short GI_InformationID { get; set; }
        public Nullable<short> StudentID { get; set; }
        public string GI_FirstName { get; set; }
        public string GI_LastName { get; set; }
        public Nullable<bool> GI_Gender { get; set; }
        public Nullable<byte> GI_Age { get; set; }
        public Nullable<byte> GI_Height { get; set; }
        public Nullable<decimal> GI_Weight { get; set; }
        public string GI_HealthStatus { get; set; }
        public string GI_YearAsMonth { get; set; }
        public Nullable<bool> GI_FamilyStatus { get; set; }
        public string GI_MotherName { get; set; }
        public string GI_MotherPhone { get; set; }
        public string GI_FatherName { get; set; }
        public string GI_FatherPhone { get; set; }
        public string GI_EmergencyName { get; set; }
        public string GI_EmergencyPhone { get; set; }
        public string GI_Province { get; set; }
        public string GI_District { get; set; }
        public string GI_Address { get; set; }
        public string GI_SpeciaInformation { get; set; }
    
        public virtual Table_Student Table_Student { get; set; }
    }
}
