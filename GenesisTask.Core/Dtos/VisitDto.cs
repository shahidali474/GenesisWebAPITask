namespace GenesisTask.Core.Dtos
{
    public class VisitDto
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string Disease { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }

}
