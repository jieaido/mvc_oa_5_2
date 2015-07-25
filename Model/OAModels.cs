namespace MVCOA_5.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OAModels : DbContext
    {
        public OAModels()
            : base("name=UserModels")
        {
        }


        

        public virtual DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<ActionInfo> ActionInfo { get; set; }
        public DbSet<R_User_ActionInfo> R_User_ActionInfo { get; set; }
        public DbSet<UserInfoMeta> UserInfoMeta { get; set; }
        public DbSet<Demo> Demo { get; set; }

    }
}
