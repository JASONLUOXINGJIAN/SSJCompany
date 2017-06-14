using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSKJCompanyUI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string XH { get; set; }
        public int ClassId { get; set; }
        public bool Sex { set; get; }
    }
}