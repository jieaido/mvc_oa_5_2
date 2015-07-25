using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MVCOA_5.Model;

namespace DAL
{


    public class UserinfoDal : BaseEFDal<UserInfo>,IBaseDal<UserInfo>
    {
        public override bool Update(UserInfo entity)
        {
            var s = Oadb.UserInfo.FirstOrDefault(p => p.ID == entity.ID);
            s.Mail = entity.Mail;
            s.UserName = entity.UserName;
            s.Phone = entity.Phone;
            s.Pwd = entity.Pwd;
            
           return  Oadb.SaveChanges() > 0;
        }

        public IQueryable<UserInfo> SearchQuery(IQueryable<UserInfo> tobeserachquery, string name="", string mail="")
        {
            IQueryable<UserInfo> s=tobeserachquery;
            if (!string.IsNullOrEmpty(name))
            {
                s= s.Where(u => u.UserName.Contains(name));
            }
            if (!string.IsNullOrEmpty(mail))
            {
                s=s.Where(u => u.Mail.Contains(mail));
            }

            return s;
        } 
    }
} 

    