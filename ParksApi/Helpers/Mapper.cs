using AutoMapper;
using ParksApi.Entities;
using ParksApi.Models;

namespace ParksApi.Helpers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      #region Park
      CreateMap<Park, ViewPark>();

      CreateMap<CreatePark, Park>();

      CreateMap<UpdatePark, Park>();
      #endregion

      #region User
      CreateMap<ApplicationUser, ViewUser>();

      CreateMap<RegisterUser, ApplicationUser>();
      #endregion
    }
  }
}