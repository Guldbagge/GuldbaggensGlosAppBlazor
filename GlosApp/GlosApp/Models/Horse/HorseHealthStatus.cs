namespace GlosApp.Models.Horse
{
    public class HorseHealthStatus
    {
        public int Id { get; set; }
        public string StatusText { get; set; } = string.Empty;
        public string Color { get; set; } = "Green";
    }
}
