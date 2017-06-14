using SSKJ.ISSKJCompanyBLL;
using SSKJ.SSKJCompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSKJCompanyUI.Controllers
{
    public class StudentController : Controller
    {

        [Ninject.Inject]
        public IStudetBLL studentBll { get; set; }
        // GET: Student
        public ActionResult Student()
        {
            return View();
        }
        public JsonResult GetList(int limit,int offset)
        {
            List<Student> list = new List<Student> ();
            list = studentBll.GetList(g=>g.StudentId>0).ToList();
            List<Models.Student> _model = new List<Models.Student>();

            foreach (var item in list)
            {
                Models.Student m = new Models.Student();

                m.StudentId =item.StudentId ;
                m.Name =item.Name ;
                m.XH =item.XH;
                m.ClassId =Convert.ToInt32(item.ClassId);
                m.Sex =Convert.ToBoolean(item .Sex);

                _model.Add(m);

            }

            var rows = _model.Skip(offset).Take(limit).ToList();
            return Json(new { total = _model.Count(), row = rows }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ContentResult AddStudent(string name, int studentId,int classId,bool sex)
        {
            Student model = new Student();
            model.Name = name;
            model.StudentId = studentId;
            model.ClassId = classId;
            model.Sex = sex;

            Student  r = studentBll.AddInfo(model);
            if (r.StudentId > 0)
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