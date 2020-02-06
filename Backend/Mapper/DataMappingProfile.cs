using AutoMapper;
using Business.BranchOffices;
using Business.MedicalInsurances;

namespace Mapper
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            this.ForAllMaps((typeMap, map) =>
            {
                map.PreserveReferences();
                map.ReverseMap();
            });

            this.CreateMap<BranchOfficeMicroServiceLite, BranchOffice>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address + src.AddressNumber));

            this.CreateMap<BranchOfficeMicroService, BranchOfficeLite>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address + src.AddressNumber));
        }
    }
}