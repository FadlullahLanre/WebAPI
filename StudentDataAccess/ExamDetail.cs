//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExamDetail

    {
        public ExamDetail()
        {
            DateCreated = DateTime.Now;
        }
        public string Examvenue { get; set; }
        public string SubjectOne { get; set; }
        public string SubjectTwo { get; set; }
        public string SubjectThree { get; set; }
        public string SubjectFour { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string StudentID { get; set; }
    }
}
