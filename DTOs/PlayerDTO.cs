namespace soccer_api.DTOs
{
    public class PlayerDTO
    {
        public string Name { get; set; } = string.Empty;
        public int AmountGoals { get; set; }
        public int TeamId { get; set; }
    }
}