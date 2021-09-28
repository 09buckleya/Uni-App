using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.OutServices.Models
{
    public class Record
    {
        public Record() {}
        public Record(int id, string course, string statement, string teacherContact, string teacherReference, string offer, bool firm)
        {
            ApplicationId = id; Course = course; Statement = statement; TeacherContact = teacherContact;
            TeacherReference = teacherReference; Offer = offer; Firm = firm;
        }
        public int ApplicationId { get; set; }
        public string Course { get; set; }
        public string Statement { get; set; }
        public string TeacherContact { get; set; }
        public string TeacherReference { get; set; }
        public string Offer { get; set; }
        public bool Firm { get; set; }
    }
}
