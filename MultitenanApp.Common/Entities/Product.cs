namespace MultitenanApp.Common.Entities;

public class Product: BaseEntity
{
    public string name { get; set; }
    public string description { get; set; }
    
    public DateTime createdBy { get; set; }
    public string modifiedBy { get; set; }
    
}