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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderPosition = new HashSet<OrderPosition>();
        }
    
        public int Id { get; set; }
        public string Number { get; set; }
        public int NumberOfVisitiors { get; set; }
        public int TableId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsPaid { get; set; }
        public System.DateTime DateOfAccept { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<OrderPosition> OrderPosition { get; set; }
    }
}
