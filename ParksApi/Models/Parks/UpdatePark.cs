namespace ParksApi.Models
{
  public class UpdatePark
  {
    public string Name { get; set; }
    public bool IsNational { get; set; }
    public int StateId { get; set; }
  }
}