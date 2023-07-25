namespace API.Entities;

public class AppUser
{
    // Id wird in DB automatisch zu Primary Key, wenn ich einen anders benannten Wert als PK haben will muss ich ein [Key] Attribut dransetzen (davor)
    public int Id { get; set; }
    public string UserName { get; set; }
    
}