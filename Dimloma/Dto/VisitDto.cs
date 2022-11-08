namespace Diploma.Dto
{
    public class VisitDto
    {
        //public int VisitId { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string Diagnosis { get; set; }

        // dodaj recepte 
    }
}
