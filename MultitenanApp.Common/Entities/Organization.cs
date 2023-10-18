namespace MultitenanApp.Common.Entities;

public class Organization: BaseEntity
{
    public string name { get; set; }
    
    public ICollection<User> Users { get; set; }
}