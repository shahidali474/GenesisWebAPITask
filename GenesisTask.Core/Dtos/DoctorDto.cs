using System.Web.Mvc;

namespace GenesisTask.Core.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public List<SelectListItem> DoctorData { get; set; }
    }

}
