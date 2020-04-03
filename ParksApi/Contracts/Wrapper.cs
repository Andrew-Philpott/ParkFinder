namespace ParksApi.Contracts
{
  public interface IRepositoryWrapper
  {
    IParkRepository Park { get; }
    void Save();
  }
}