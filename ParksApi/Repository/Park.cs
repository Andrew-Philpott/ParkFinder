using ParksApi.Contracts;
using ParksApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParksApi.Repository
{
  public class ParkRepository : RepositoryBase<Park>,
  IParkRepository
  {
    public ParkRepository(ParksApiContext parksApiContext) : base(parksApiContext)
    {
    }

    public Park GetPark(int id)
    {
      return FindByCondition(entry => entry.ParkId == id).FirstOrDefault();
    }

    public IEnumerable<Park> GetParks()
    {
      return FindAll().OrderBy(x => x.State);
    }

    public IEnumerable<Park> GetParksQuery(string parkName, string stateName, string isNational, string region)
    {

      IQueryable<Park> query = this.ParksApiContext.Parks.AsQueryable();
      if (parkName != null)
      {
        query = query.Where(x => x.Name == parkName);
      }
      // if (stateName != null)
      // {
      //   query = query.Where(x => x.Name == parkName);
      // }
      if (isNational != null)
      {
        if (isNational == "true")
        {
          query = query.Where(x => x.IsNational == true);
        }
        else
        {
          query = query.Where(x => x.IsNational == false);
        }
      }

      return query.ToList();
    }
  }
}