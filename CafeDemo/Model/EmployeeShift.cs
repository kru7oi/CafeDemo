//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CafeDemo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeShift
    {
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }
        public System.DateTime DateOfStart { get; set; }
        public System.DateTime DateOfEnd { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Shift Shift { get; set; }
    }
}