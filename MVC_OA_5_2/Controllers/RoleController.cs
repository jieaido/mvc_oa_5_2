using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using MVCOA_5.Model;

namespace mvc_oa_new.Controllers
{
    public class RoleController : Controller
    {
        RoleDal roleDal=new RoleDal();
        // GET: Role
        public ActionResult Index()
        {
            ViewBag.adress = Url.Action("inittable", "Role");
            ViewBag.editadress = Url.Action("updata", "Role");
            return View();
        }
        public ActionResult inittable()
        {
            var pagesize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            var pageindex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            var total = 0;
            var pagedate = roleDal.Pages(pagesize, pageindex, out total, u => u.DelFlag != 1, u => u.ID);
            

            var date = new
            {
                total,
                rows = (from d in pagedate
                        select new
                        {
                            d.ID,
                            d.RoleName,
                             d.SubBy,
                            SubName = roleDal.GetOaModels().UserInfo.Find(d.SubBy).UserName,
                            ToShortDateString = d.SubTime.ToShortDateString(),
                           
                        }
                    ).ToList()
            };
            return Json(date, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(Role role)
        {
            role.SubTime = DateTime.Now;
            if (roleDal.Add(role)!=null)
            {
                return Content("ok");
            }
            return Content("false");
        }

        public ActionResult Updata()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Updata(Role role)
        {
           // roleDal.Update(role);
            return Content("ok");
        }
    }
}