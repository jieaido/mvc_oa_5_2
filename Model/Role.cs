//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCOA_5.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.UserInfo = new HashSet<UserInfo>();
            this.ActionInfo = new HashSet<ActionInfo>();
            this.Department = new HashSet<Department>();
        }
    
        public int ID { get; set; }
        public string RoleName { get; set; }
        public short DelFlag { get; set; }
        public int SubBy { get; set; }
        public System.DateTime SubTime { get; set; }
    
        public virtual ICollection<UserInfo> UserInfo { get; set; }
        public virtual ICollection<ActionInfo> ActionInfo { get; set; }
        public virtual ICollection<Department> Department { get; set; }
    }
}
