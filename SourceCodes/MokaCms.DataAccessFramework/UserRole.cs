//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MokaCms.DataAccessFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
