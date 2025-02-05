namespace soccer_api.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FoundedYear { get; set; }
        public float Income { get; set; }
        public string City { get; set; } = string.Empty;
    }
}