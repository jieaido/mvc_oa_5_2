using System;
using System.Linq;
using System.Web.Mvc;
using DAL;
using MVCOA_5.Model;

namespace mvc_oa_new.Controllers
{
    public class UserinfoController : Controller
    {
        //
        // GET: /Userinfo/
        UserinfoDal _userinfoDal = new UserinfoDal();
       

          



        public ActionResult Index()
        {
            var userinfos = _userinfoDal.Select(u => u.ID > 0);
            return View(userinfos);
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                UserInfo userInfo = new UserInfo()
                {
                    UserName = collection["UserName"],
                    DelFlag = 0,
                    SubBy = 0,
                    SubTime = DateTime.Now,
                    Pwd = collection["Pwd"],
                    Mail = collection["Mail"]
                    ,
                    Phone = collection["Phone"]
                };
                if (_userinfoDal.Add(userInfo) != null)
                {
                    return Content("OK");
                }
                else
                {
                    return Content("fuck");
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Userinfo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Userinfo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Userinfo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Userinfo/Delete/5

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
                    _userinfoDal.Deletes(int.Parse(id.ToString()));
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

        public ActionResult inittable(string SName,string SMail)
        {
            int pagesize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageindex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;
            var pagedate = _userinfoDal.Pages(pagesize, pageindex, out total, u => u.DelFlag != 1, u => u.ID);
           pagedate=  _userinfoDal.SearchQuery(pagedate, SName, SMail);

            var date = new
            {
                total = total,
                rows = (from u in pagedate
                        select new
                        {
                            u.ID,
                            u.UserName,
                            u.Pwd,
                            u.Mail,
                            u.Phone,

                        }
                    ).ToList()
            };
            return Json(date, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Updata(int id)
        {
          var s = _userinfoDal.Select(p => p.ID == id).FirstOrDefault();



            return View(s);
        }
        [HttpPost]
        public ActionResult Updata( UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return Content("Fuck");
            }
            else
            {
                //  OAModelFactory.GetOaModels().Entry(userInfo).CurrentValues.SetValues(ui);
                if (_userinfoDal.Update(userInfo))
                {
                    return Content("ok");
                }
                return Content("Fuck");
            }
        }
    }
}
