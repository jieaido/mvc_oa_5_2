using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using MVCOA_5.Model;

namespace mvc_oa_new.Controllers
{
    public class DepartmentController : Controller
    {
       private  DepartmentDal departmentDal = new DepartmentDal();

        public ActionResult Index()
        {
            //var userinfos = departmentDal.Select(u => u.ID > 0);
            return View();
        }

        //
        // GET: /Userinfo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Userinfo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Userinfo/Create

        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {

                department.DelFlag = 0;
                department.IsLeaf = true;
                department.Level = 0;
                department.ParentId = 0;
                department.SubBy = 0;
                department.SubTime = DateTime.Now;
                department.TreePath = string.Empty;

          
                if (departmentDal.Add(department) != null)
                {
                    return Content("OK");
                }
                return Content("fuck");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(string ids)
        {
            try
            {
                // TODO: Add delete logic here
                //string[] fuckid = c.Split(',');
                //
                foreach (var id in ids.Split(','))
                {
                    departmentDal.Deletes(int.Parse(id));
                }
                return Content("OK");
            }
            catch
            {
                return Content("Fuck");
            }
        }

        public ActionResult ShowUser()
        {
            return View();
        }

        public ActionResult inittable()
        {
            var pagesize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            var pageindex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            var total = 0;
            var pagedate = departmentDal.Pages(pagesize, pageindex, out total, u => u.DelFlag != 1, u => u.ID);
           

            var date = new
            {
                total,
                rows = (from d in pagedate
                        select new
                        {
                            d.ID,
                            d.DepName,
                            d.DelFlag,
                            d.DepMasterId,
                            d.DepNo, ToShortDateString = d.SubTime.ToShortDateString(),
                            d.SubBy
                        }
                    ).ToList()
            };
            return Json(date, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Updata(int id)
        {
            var s = departmentDal.Select(p => p.ID == id).FirstOrDefault();


            return View(s);
        }

        [HttpPost]
        public ActionResult Updata(Department department)
        {
            if (department == null)
            {
                return Content("Fuck");
            }
            //  OAModelFactory.GetOaModels().Entry(userInfo).CurrentValues.SetValues(ui);
            if (departmentDal.Update(department))
            {
                return Content("ok");
            }
            return Content("Fuck");
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
    //            departmentDal.GetOaModels().Dispose();
            }
            base.Dispose(disposing);
        }
    }
 
        
       
    }

