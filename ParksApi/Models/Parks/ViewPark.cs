namespace ParksApi.Models
{
  public class ViewPark
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsNational { get; set; }

    public string StateId { get; set; }

    public string StateName { get; set; }

    public string Region { get; set; }
  }
}