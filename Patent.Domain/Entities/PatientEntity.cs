namespace Patent.Domain.Entities
{
    public class PatientEntity
    {
        public int idPatient { get; set; }
        public string TypeDocument { get; set; }
        public long numberDocument { get; set; }
        public string namePatient { get; set; }
        public DateTime dateBirth { get; set; }
        public string email { get; set; }
        public string Gender { get; set; }
        public string address { get; set; }
        public long numberPhone { get; set; }
        public bool active { get; set; }
    }
}
