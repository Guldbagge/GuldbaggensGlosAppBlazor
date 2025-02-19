namespace GlosApp.Models.Horse
{
    public class HorseDiaryEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public int RidingMinutes { get; set; }
        public List<string> RidingTypes { get; set; } = new();
        public string Intensity { get; set; } = "Medel"; // Default till medel
        public string Rider { get; set; } = "Alma";
        public string Notes { get; set; } = string.Empty;
    }

}
