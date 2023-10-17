namespace MultitenanApp.Common.Entities;

public class User: BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public bool isActive { get; set; }
    
    public DateTime creationDate { get; set; }
    public DateTime ModifiedBy { get; set; }
    
}