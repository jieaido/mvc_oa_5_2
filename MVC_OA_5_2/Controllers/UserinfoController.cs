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
        private readonly UserinfoDal _userinfoDal = new UserinfoDal();

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
                var userInfo = new UserInfo
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
                    _userinfoDal.Deletes(int.Parse(id));
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

        public ActionResult inittable(string SName, string SMail)
        {
            var pagesize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            var pageindex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            var total = 0;
            var pagedate = _userinfoDal.Pages(pagesize, pageindex, out total, u => u.DelFlag != 1, u => u.ID);
            pagedate = _userinfoDal.SearchQuery(pagedate, SName, SMail);

            var date = new
            {
                total,
                rows = (from u in pagedate
                    select new
                    {
                        u.ID,
                        u.UserName,
                        u.Pwd,
                        u.Mail,
                        u.Phone
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
        public ActionResult Updata(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return Content("Fuck");
            }
            //  OAModelFactory.GetOaModels().Entry(userInfo).CurrentValues.SetValues(ui);
            if (_userinfoDal.Update(userInfo))
            {
                return Content("ok");
            }
            return Content("Fuck");
        }

        public ActionResult SetRole(int id)
        {
            //todo 增加id,把要修改的用户拿出来
           var models= _userinfoDal.GetOaModels().Role.Where(p => p.ID > 0).AsQueryable();
            return View(models);
        }

        public ActionResult list()
        {
            return null;
        }
        [HttpPost]
        public ActionResult SetRole(FormCollection formCollection)
        {

           //todo 根据拿出来的用户设置权限 

           
            var models = formCollection;
            return View(models);
        }
    }
}