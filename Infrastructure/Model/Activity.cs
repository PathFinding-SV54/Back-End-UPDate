namespace Infrastructure.Model;

public class Activity
{
    /*
     * [required]
     * [MaxLength(10)]
     * validaciones para los datos
     */
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Date { get; set; }
    
    public  bool IsActive { get; set; }
    
}