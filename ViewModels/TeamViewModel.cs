namespace soccer_api.ViewModels;

public class TeamViewModel
{
    public string Name { get; set; } = string.Empty;
    public int FoundedYear { get; set; }
    public float Income { get; set; }
    public string City { get; set; } = string.Empty;
}