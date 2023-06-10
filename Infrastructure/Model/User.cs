namespace Infrastructure.Model;

public class User
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    
    public string Bio { get; set; }
    
    public string Gender { get; set; }
    
    public DateTime Registro { get; set; }
    public string Birthday { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public int UniversityId { get; set; }
    
    public University University { get; set; }
    
}