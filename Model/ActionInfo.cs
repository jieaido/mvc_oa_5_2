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
    
    public partial class ActionInfo
    {
        public ActionInfo()
        {
            this.Role = new HashSet<Role>();
            this.R_User_ActionInfo = new HashSet<R_User_ActionInfo>();
        }
    
        public int ID { get; set; }
        public short DelFlag { get; set; }
        public int SubBy { get; set; }
        public System.DateTime SubTime { get; set; }
        public string Url { get; set; }
        public string HttpMethod { get; set; }
        public string ActionName { get; set; }
        public string Remark { get; set; }
        public string Controoller { get; set; }
        public string ActionMethod { get; set; }
    
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<R_User_ActionInfo> R_User_ActionInfo { get; set; }
    }
}
