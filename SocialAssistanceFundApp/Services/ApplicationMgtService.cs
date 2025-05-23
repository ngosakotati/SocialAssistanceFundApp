using SocialAssistanceFundApp.Interfaces;
using SocialAssistanceFundApp.Models.AddressInfo;
using SocialAssistanceFundApp.Models.ApplicantInfo;
using SocialAssistanceFundApp.Models.ApplicationInfo;

namespace SocialAssistanceFundApp.Services
{
    public class ApplicationMgtService(IRepository<Application> applicationRepository, IRepository<Applicant> applicantRepository,
        IRepository<MaritalStatus> maritalStatusRepository, IRepository<Sex> sexRepository, IRepository<Village> villageRepository,
        IRepository<TelephoneContact> telContacteRepository, IRepository<SocialAssistanceProgram> programRepository)
    {
        private readonly IRepository<Application> _applicationRepository = applicationRepository;
        private readonly IRepository<Applicant> _applicantRepository = applicantRepository;
        private readonly IRepository<MaritalStatus> _maritalStatusRepository = maritalStatusRepository;
        private readonly IRepository<Sex> _sexRepository = sexRepository;
        private readonly IRepository<Village> _villageRepository = villageRepository;
        private readonly IRepository<TelephoneContact> _telContacteRepository = telContacteRepository;
        private readonly IRepository<SocialAssistanceProgram> _programRepository = programRepository;

        // METHODS

        /*public async Task<Application> CreateApplication(Application application)
        {

        }*/
    }
}
