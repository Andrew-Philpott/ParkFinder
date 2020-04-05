namespace ParksApi.Contracts
{
  public interface IRepositoryWrapper
  {
    IStateRepository State { get; }
    IParkRepository Park { get; }
    IUserRepository User { get; }
    void Save();
  }
}