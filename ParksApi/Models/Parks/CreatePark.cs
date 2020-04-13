namespace ParksApi.Models
{
  public class CreatePark
  {
    public string Name { get; set; }
    public bool IsNational { get; set; }
    public int StateId { get; set; }
  }
}