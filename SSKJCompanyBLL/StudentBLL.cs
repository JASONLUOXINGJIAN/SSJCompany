using SSKJ.ISSKJCompanyBLL;
using SSKJ.ISSKJCompanyDAL;
using SSKJ.SSKJCompanyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSKJ.SSKJCompanyBLL
{
    public class StudentBLL : IStudetBLL
    {
        [Ninject.Inject]
        public IStudentDAL CurrentDAL { get; set; }
        public StudentBLL()
        {

        }

        public Student AddInfo(Student model)
        {
            return CurrentDAL.Add(model);
        }

        public int DeleteInfo(int[] delbyid)
        {
            delbyid.ToList().ForEach(id =>
            {
                CurrentDAL.Remove(GetList(p => p.StudentId == id).Single());
            });

            return CurrentDAL.SaveChange();
        }

        public IEnumerable<Student> GetList(Expression<Func<Student, bool>> whereLambda)
        {
            return CurrentDAL.Find(whereLambda);
        }

        public IEnumerable<Student> GetList_page<S>(int pageIndex, int pageSize, Expression<Func<Student, bool>> whereLambda, bool isAsc, Expression<Func<Student, S>> orderbyLambda, out int total)
        {
            return CurrentDAL.FindPaging<S>(pageIndex, pageSize, whereLambda, isAsc, orderbyLambda, out total);
        }
        public int UpdateInfo(Student model)
        {
            return CurrentDAL.Modified(model);
        }
        public List<Student> SaveList(Stream file, Student model)
        {
            throw new NotImplementedException();
        }

        public int SaveChangeInfo(Student model)
        {
            return CurrentDAL.SaveChange();
        }
    }
}
