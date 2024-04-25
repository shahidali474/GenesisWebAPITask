using GenesisTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GenesisTask.Data.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string Disease { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
