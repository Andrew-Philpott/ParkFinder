using ParksApi.Contracts;
using ParksApi.Helpers;
using ParksApi.Entities;
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

    public Park GetParkById(int id)
    {
      return FindByCondition(entry => entry.Id == id).SingleOrDefault();
    }

    public IEnumerable<Park> GetAllParks()
    {
      return FindAll().OrderBy(x => x.Name);
    }

    public IEnumerable<Park> GetParksQuery(string parkName, string isNational, IQueryable<State> states)
    {
      IQueryable<Park> query = null;
      if (states != null)
      {
        query = (from p in FindAll() join s in states on p.StateId equals s.Id select p);
      }
      else
      {
        query = (FindAll().AsQueryable());
      }
      if (parkName != null)
      {
        query = query.Where(x => x.Name == parkName);
      }
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

    public void CreatePark(Park park)
    {
      Create(park);
    }

    public void UpdatePark(int id, Park parkToUpdate)
    {
      var park = GetParkById(id);
      if (park == null)
        throw new AppException("Park not found");
      parkToUpdate.Id = id;
      Update(parkToUpdate);
    }

    public void DeletePark(int id)
    {
      var park = GetParkById(id);
      if (park != null)
        Delete(park);
    }
  }
}