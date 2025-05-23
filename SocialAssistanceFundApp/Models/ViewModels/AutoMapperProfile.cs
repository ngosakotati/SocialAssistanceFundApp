using AutoMapper;
using SocialAssistanceFundApp.Models.AddressInfo;
using SocialAssistanceFundApp.Models.ApplicantInfo;
using SocialAssistanceFundApp.Models.ApplicationInfo;

namespace SocialAssistanceFundApp.Models.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Application, ApplicationViewModel>()
                .ForMember(dest => dest.SocialAssistanceProgram, opt => opt.MapFrom(src => src.SocialAssistanceProgram.Name))
                .ForMember(dest => dest.Applicant, opt => opt.MapFrom(src => src.Applicant != null ? src.Applicant : null))
                .ReverseMap();

            CreateMap<Applicant, ApplicantViewModel>()
                .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex.Name))
                .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.Status))
                .ForMember(dest => dest.TelePhoneContact, opt => opt.MapFrom(src => src.TelephoneContacts.FirstOrDefault().TelephoneNo))
                .ForMember(dest => dest.Village, opt => opt.MapFrom(src => src.Village.Name))
                .ReverseMap();

            CreateMap<CreateApplicationViewModel, Applicant>()
                .ForMember(dest => dest.SexId, opt => opt.MapFrom(src => src.SexId))
                .ForMember(dest => dest.MaritalStatusId, opt => opt.MapFrom(src => src.MaritalStatusId))
                .ForMember(dest => dest.VillageId, opt => opt.MapFrom(src => src.VillageId))
                .ForMember(dest => dest.TelephoneContacts, opt => opt.MapFrom(src =>
                    src.TelephoneContacts != null
                        ? src.TelephoneContacts
                            .Where(p => !string.IsNullOrWhiteSpace(p))
                            .Select(p => new TelephoneContact { TelephoneNo = p })
                            .ToList()
                        : new List<TelephoneContact>()
                ));

            CreateMap<Applicant, CreateApplicationViewModel>()
                .ForMember(dest => dest.SexId, opt => opt.MapFrom(src => src.Sex.Id))
                .ForMember(dest => dest.MaritalStatusId, opt => opt.MapFrom(src => src.MaritalStatus.Id))
                .ForMember(dest => dest.VillageId, opt => opt.MapFrom(src => src.Village.Id))
                .ForMember(dest => dest.TelephoneContacts, opt => opt.MapFrom(src =>
                    src.TelephoneContacts != null
                        ? src.TelephoneContacts.Select(tc => tc.TelephoneNo).ToList()
                        : new List<string>()
                ));

            CreateMap<Application, CreateApplicationViewModel>()
                .ForMember(dest => dest.SexId, opt => opt.MapFrom(src => src.Applicant.Sex.Id))
                .ForMember(dest => dest.MaritalStatusId, opt => opt.MapFrom(src => src.Applicant.MaritalStatus.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Applicant.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.Applicant.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Applicant.LastName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Applicant.Age))
                .ForMember(dest => dest.IdNumber, opt => opt.MapFrom(src => src.Applicant.IdNumber))
                .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(src => src.Applicant.PostalAddress))
                .ForMember(dest => dest.PhysicalAddress, opt => opt.MapFrom(src => src.Applicant.PhysicalAddress))
                .ForMember(dest => dest.SocialAssistanceProgramId, opt => opt.MapFrom(src => src.SocialAssistanceProgram.Id))
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.Applicant.Village.SubLocation.Location.Id))
                .ForMember(dest => dest.SubLocationId, opt => opt.MapFrom(src => src.Applicant.Village.SubLocation.Id))
                .ForMember(dest => dest.CountyId, opt => opt.MapFrom(src => src.Applicant.Village.SubLocation.Location.SubCounty.CountyId))
                .ForMember(dest => dest.SubCountyId, opt => opt.MapFrom(src => src.Applicant.Village.SubLocation.Location.SubCounty.Id))
                .ForMember(dest => dest.VillageId, opt => opt.MapFrom(src => src.Applicant.Village.Id))
                .ForMember(dest => dest.TelephoneContacts, opt => opt.MapFrom(src =>
                src.Applicant.TelephoneContacts != null
                    ? src.Applicant.TelephoneContacts.Select(tc => tc.TelephoneNo).ToList()
                    : new List<string>()
                ));

            CreateMap<CreateApplicationViewModel, Application>()
                .ForMember(dest => dest.SocialAssistanceProgram, opt => opt.MapFrom(src => new SocialAssistanceProgram
                {
                    Id = src.SocialAssistanceProgramId
                }))
                .ForMember(dest => dest.Applicant, opt => opt.MapFrom(src => new Applicant
                {
                    FirstName = src.FirstName,
                    MiddleName = src.MiddleName,
                    LastName = src.LastName,
                    Age = src.Age,
                    IdNumber = src.IdNumber,
                    PostalAddress = src.PostalAddress,
                    PhysicalAddress = src.PhysicalAddress,
                    Sex = new Sex { Id = src.SexId },
                    MaritalStatus = new MaritalStatus { Id = src.MaritalStatusId },
                    Village = new Village
                    {
                        Id = src.VillageId,
                        SubLocation = new SubLocation
                        {
                            Id = src.SubLocationId,
                            Location = new Location
                            {
                                Id = src.LocationId,
                                SubCounty = new SubCounty
                                {
                                    CountyId = src.CountyId
                                }
                            }
                        }
                    },
                    TelephoneContacts = src.TelephoneContacts != null
                        ? src.TelephoneContacts
                            .Where(p => !string.IsNullOrWhiteSpace(p))
                            .Select(p => new TelephoneContact { TelephoneNo = p })
                            .ToList()
                        : new List<TelephoneContact>()
                }));

        }
    }
}
