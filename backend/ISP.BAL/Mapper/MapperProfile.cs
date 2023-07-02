using AutoMapper;
using ISP.BAL.DTOS;
using ISP.BAL.DTOS.BranchesDtos;
using ISP.BAL.DTOS.BundleDTOs;
using ISP.BAL.DTOS.CentralsDtos;
using ISP.BAL.DTOS.ClientDTOs;
using ISP.BAL.DTOS.OfferDtos;
using ISP.BAL.DTOS.UsersDtos;
using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {

            CreateMap<Group, GroupDTO>().ReverseMap();

            CreateMap<Branch, ViewBranchDto>()
                .ForMember(dest  => dest.governate , src => src.MapFrom(src => src.governarate.Name))
                .ForMember(dest => dest.Manager , src => src.MapFrom(src => src.Magnager.UserName))
                .ReverseMap();

            CreateMap<Branch , EditAddBranchDto>()
                .ForMember(dest => dest.Id , src=> src.MapFrom(src => src.Id))
                .ReverseMap();

         
            CreateMap<Central, ViewCentralDto>()
                    .ForMember(dest => dest.governarate , src => src.MapFrom(src => src.Governarate.Name))
                    .ReverseMap();
        
            CreateMap<Central , AddEditCentralDto>()
                .ReverseMap();

            //Bundle
            CreateMap<Bundle, ViewBundleDto>()
                      .ForMember(dst => dst.ProviderName, src => src.MapFrom(src => src.provider.Name))
                      .ReverseMap();
            CreateMap<Bundle, EditBundleDto>()
                     .ReverseMap();

            CreateMap<Bundle, AddBundleDto>()
                   .ReverseMap();
            CreateMap<Offer, OfferDto>()
                 .ForMember(dest => dest.BranchNames, opt => opt.MapFrom(src => src.Branches.Select(b => b.Name)))
                 .ReverseMap();
            CreateMap<Offer, AddEditOffer>()
                 
                  .ReverseMap();


            // users 
            // show manager
            CreateMap<User, ViewManagersDtos>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ForMember(dest => dest.userName, src => src.MapFrom(src => src.UserName))
                .ReverseMap();


            // add user 

            CreateMap<RegisterDto, RegisterForm>()
                .ReverseMap();

            // view user 
            CreateMap<User, ViewUserDto>()
                .ForMember(dest => dest.branch, src => src.MapFrom(src => src.branch.Name))
                .ForMember(dest => dest.group, src => src.MapFrom(src => src.group.Name))
                .ReverseMap();

            //Client
            CreateMap<Client, ViewClientDto>()
                     .ForMember(dst => dst.ProviderName, src => src.MapFrom(src => src.Provider.Name))
                     .ForMember(dst => dst.GovernarateName, src => src.MapFrom(src => src.Governarate.Name))
                     .ForMember(dst => dst.Branch, src => src.MapFrom(src => src.Branch.Name))
                     .ForMember(dst => dst.Bundle, src => src.MapFrom(src => src.Bundle.Name))
                     .ForMember(dst => dst.Central, src => src.MapFrom(src => src.Central.Name))
                     .ReverseMap();

            CreateMap<Client, AddEditClientDto>()
                .ReverseMap();
            CreateMap<Client, DeleteClientDto>()
                .ReverseMap();




        }
    }
}
