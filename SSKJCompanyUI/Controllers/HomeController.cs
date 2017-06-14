using SSKJ.ISSKJCompanyBLL;
using SSKJ.SSKJCompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSKJCompanyUI.Controllers
{
    public class HomeController : Controller
    {
        [Ninject.Inject]
        public IClassBLL classBll { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取班级信息的列表
        /// </summary>
        /// <param name="limit">页面大小</param>
        /// <param name="offset">页码</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetList(int limit, int offset)
        {
            List<Class> list = new List<Class>();
            list = classBll.GetList(g => g.ClassId > 0).ToList();
            List<Models.Class> _model = new List<Models.Class>();

            foreach (var item in list)
            {
                Models.Class m = new Models.Class();

                m.ClassId = item.ClassId;
                m.ClassName = item.ClassName;
                m.PersonNumber = item.PersonNumber;

                _model.Add(m);

            }
            var rows = _model.Skip(offset).Take(limit).ToList();
            var j=Json(new { total = _model.Count(), rows = rows }, JsonRequestBehavior.AllowGet);
            return j;
        }

        /// <summary>
        /// 添加班级信息
        /// </summary>
        /// <param name="number">班级人数</param>
        /// <param name="className">班级名称</param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult AddClass(int number, string className)
        {
            Class model = new Class();
            model.ClassName = className;
            model.PersonNumber = number;

            Class r = classBll.AddInfo(model);
            if (r.ClassId > 0)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }

        }

        /// <summary>
        /// 修改班级信息
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <param name="number">班级人数</param>
        /// <param name="className">班级名称</param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult EditClass(string id, string number, string className)
        {
            var _id = Convert.ToInt32(id);

            Class model = classBll.GetList(g => g.ClassId == _id).Single();
            model.ClassName = className;
            model.PersonNumber = Convert.ToInt32(number);

            int r = classBll.UpdateInfo(model);
            if (r > 0)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }

        }

        /// <summary>
        /// 删除班级信息
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <returns></returns>
        public ContentResult DeleteClass(string id)
        {
            var _id = Convert.ToInt32(id);

            int[] ids = new int[] { _id };

            int r = classBll.DeleteInfo(ids);
            if (r > 0)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
        }
    }
}