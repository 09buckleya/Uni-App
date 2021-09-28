using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.OutServices.Models;
namespace NAA.OutServices.Models
{
    public class Category
    {
        public int ApplicationId { get; set; }
        public string Course { get; set; }
        public string Statement { get; set; }
        public string TeacherContact { get; set; }
        public string TeacherReference { get; set; }
        public string Offer { get; set; }
        public bool Firm { get; set; }
    }
}
