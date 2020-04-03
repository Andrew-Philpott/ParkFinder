using ParksApi.Models;
using System.Collections.Generic;

namespace ParksApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IParkRepository Park { get; }
    }
}