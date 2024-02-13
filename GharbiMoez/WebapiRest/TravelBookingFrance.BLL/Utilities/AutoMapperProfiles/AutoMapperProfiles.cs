using AutoMapper;
using TravelBookingFrance.BLL.Features.Product.Queries.Response;
using TravelBookingFrance.BLL.Features.Travel.Queries.Response;
using TravelBookingFrance.DAL.Entities;
using TravelBookingFrance.DTO.DTOs;

namespace TravelBookingFrance.BLL.Utilities.AutoMapperProfiles;

public static class AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Activite, ActivityDTO>().ReverseMap();
            CreateMap<Customer, UserDTO>().ReverseMap();
            CreateMap<Customer, UserToAddDTO>().ReverseMap();
            CreateMap<Customer, UserToUpdateDTO>().ReverseMap();
            CreateMap<Customer, UserToRegisterDTO>().ReverseMap();
            CreateMap<Customer, UserToReturnDTO>().ReverseMap();
            CreateMap<Travel, GetTravelListByCustomerIdDTO>().ReverseMap();
            CreateMap<Product, GetProductListByTravelIdResponse>()
                 .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(photo => photo.Url).ToList())); ;

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(photo => photo.Url).ToList()));

            CreateMap<Travel, GetTravelListByCustomerIdResponse>()
                 .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.TravelProducts.Select(tp => new ProductDTO
                 {
                     ProdName = tp.Product.ProdName,
                     ProdDescription = tp.Product.ProdDescription,
                     Photos = tp.Product.Photos.Select(photo => photo.Url).ToList()
                 })))
                 /*.ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.TravelActivities.Select(x => x.Activite)))*/
                 .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.TActivities
                 .Select(a => new ActivityDTO
                 {
                     ActivityId = a.Activite.ActivityId,
                     Nom = a.Activite.Nom,
                     Lieu = a.Activite.Lieu,
                     Durée = a.Activite.Durée,
                     Prix = a.Activite.Prix,
                     UrlImageAct = a.Activite.UrlImageAct
                 })))
                .ForMember(dest => dest.Ttname, opt => opt.MapFrom(src => src.TripType.Ttname))
                .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight.FlightNumber))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Flight.CompanyName))
                .ForMember(dest => dest.DateOfDepart, opt => opt.MapFrom(src => src.Flight.DateOfDepart))
                .ForMember(dest => dest.DateOfArrival, opt => opt.MapFrom(src => src.Flight.DateOfArrival))
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.Flight.SeatNumber));

        }

    }
}
