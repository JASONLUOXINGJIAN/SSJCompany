using SSKJ.ISSKJCompanyBLL;
using SSKJ.ISSKJCompanyDAL;
using SSKJ.SSKJCompanyBLL;
using SSKJ.SSKJCompanyDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSKJ.NinjectBinder
{
    public class Binder<T> where T : Ninject.IKernel
    {
        public static void BindBLL(T kernel)
        {
            kernel.Bind<IStudetBLL>().To<StudentBLL>();
            kernel.Bind<IClassBLL>().To<ClassBLL>();
        }

        public static void BindDAL(T kernel)
        {
            kernel.Bind<IClassDAL>().To<ClassDAL>();
            kernel.Bind<IStudentDAL>().To<StudentDAL>();
        }
    }
}