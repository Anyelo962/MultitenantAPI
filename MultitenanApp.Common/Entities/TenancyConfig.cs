namespace MultitenanApp.Common.Entities;


//This model is for show the configuration for each tenancy
public class TenancyConfig
{
    public int Id { get; set; }
    public string name { get; set; }
    public string ConnectionString { get; set; }
}