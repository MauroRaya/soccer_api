namespace soccer_api.DTOs;

public class TeamDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int FoundedYear { get; set; }
    public string City { get; set; } = string.Empty;
}