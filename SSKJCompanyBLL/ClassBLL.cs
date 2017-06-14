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
    public class ClassBLL : IClassBLL
    {
        [Ninject.Inject]
        public IClassDAL CurrentDAL { get; set; }

        public Class AddInfo(Class model)
        {
            return CurrentDAL.Add(model);
        }

        public int DeleteInfo(int[] delbyid)
        {
            delbyid.ToList().ForEach(id =>
            {
                CurrentDAL.Remove(GetList(p => p.ClassId == id).Single());
            });

            return CurrentDAL.SaveChange();
        }

        public IEnumerable<Class> GetList(Expression<Func<Class, bool>> whereLambda)
        {
            return CurrentDAL.Find(whereLambda);
        }

        public IEnumerable<Class> GetList_page<S>(int pageIndex, int pageSize, Expression<Func<Class, bool>> whereLambda, bool isAsc, Expression<Func<Class, S>> orderbyLambda, out int total)
        {
            return CurrentDAL.FindPaging<S>(pageIndex, pageSize, whereLambda, isAsc, orderbyLambda, out total);
        }

        public List<Class> SaveList(Stream file, Class model)
        {
            throw new NotImplementedException();
        }

        public int UpdateInfo(Class model)
        {
            return CurrentDAL.SaveChange();
        }
    }
}
