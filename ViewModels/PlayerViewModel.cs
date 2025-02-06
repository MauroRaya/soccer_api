namespace soccer_api.ViewModels
{
    public class PlayerViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int AmountGoals { get; set; }
        public float Salary { get; set; }
        public int TeamId { get; set; }
    }
}