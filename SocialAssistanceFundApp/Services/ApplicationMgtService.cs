using Microsoft.EntityFrameworkCore;
using SocialAssistanceFundApp.Interfaces;
using SocialAssistanceFundApp.Models.AddressInfo;
using SocialAssistanceFundApp.Models.ApplicantInfo;
using SocialAssistanceFundApp.Models.ApplicationInfo;

namespace SocialAssistanceFundApp.Services
{
    public class ApplicationMgtService(IRepository<Application> applicationRepository, IRepository<Applicant> applicantRepository,
        IRepository<MaritalStatus> maritalStatusRepository, IRepository<Sex> sexRepository, IRepository<Village> villageRepository,
        IRepository<TelephoneContact> telContacteRepository, IRepository<SocialAssistanceProgram> programRepository,
        IRepository<County> countyRepository, IRepository<SubCounty> subCountyRepository, IRepository<Location> locationRepository,
        IRepository<SubLocation> subLocationRepository)
    {
        private readonly IRepository<Application> _applicationRepository = applicationRepository;
        private readonly IRepository<Applicant> _applicantRepository = applicantRepository;
        private readonly IRepository<MaritalStatus> _maritalStatusRepository = maritalStatusRepository;
        private readonly IRepository<Sex> _sexRepository = sexRepository;
        private readonly IRepository<Village> _villageRepository = villageRepository;
        private readonly IRepository<TelephoneContact> _telContacteRepository = telContacteRepository;
        private readonly IRepository<SocialAssistanceProgram> _programRepository = programRepository;
        private readonly IRepository<County> _countyRepository = countyRepository;
        private readonly IRepository<SubCounty> _subCountyRepository = subCountyRepository;
        private readonly IRepository<Location> _locationRepository = locationRepository;
        private readonly IRepository<SubLocation> _subLocationRepository = subLocationRepository;

        // METHODS

        public async Task<List<Application>> GetAllApplicationsAsync()
        {
            var applications = await _applicationRepository
                .AllIncludingQueryable(a => a.Applicant, a => a.Applicant.Sex, a => a.Applicant.MaritalStatus, a => a.Applicant.TelephoneContacts,
                    a => a.Applicant.Village, a => a.Applicant.Village.SubLocation, a => a.Applicant.Village.SubLocation.Location,
                    a => a.SocialAssistanceProgram)
                .ToListAsync();

            return applications;
        }

        public async Task<Application> GetApplicationById(int id)
        {
            var application = await _applicationRepository
                .AllIncludingQueryable(a => a.Applicant, a => a.Applicant.Sex, a => a.Applicant.MaritalStatus, a => a.Applicant.TelephoneContacts,
                    a => a.Applicant.Village, a => a.Applicant.Village.SubLocation, a => a.Applicant.Village.SubLocation.Location,
                    a => a.SocialAssistanceProgram)
                .Include(a => a.Applicant.Village.SubLocation.Location.SubCounty)
                .ThenInclude(s => s.County)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return application;
        }

        public async Task<Applicant> CreateApplicant(Applicant applicant)
        {
            _applicantRepository.Add(applicant);
            await _applicationRepository.SaveChangesAsync();

            return applicant;
        }

        public async Task<Application> CreateApplication(Application application)
        {
            _applicationRepository.Add(application);
            await _applicationRepository.SaveChangesAsync();

            return application;
        }

        public async Task<Application> UpdateApplication(Application application)
        {
            _applicationRepository.Update(application);
            await _applicationRepository.SaveChangesAsync();

            return application;
        }

        public async Task<List<Sex>> GetSexes()
        {
            var sexes = await _sexRepository.AllIncludingQueryable().ToListAsync();

            return sexes;
        }

        public async Task<List<MaritalStatus>> GetMaritalStatuses()
        {
            var maritalStatuses = await _maritalStatusRepository.AllIncludingQueryable().ToListAsync();

            return maritalStatuses;
        }
        public async Task<List<County>> GetCounties()
        {
            var counties = await _countyRepository.AllIncludingQueryable().ToListAsync();

            return counties;
        }
        public async Task<List<SubCounty>> GetSubCounties()
        {
            var subCounties = await _subCountyRepository.AllIncludingQueryable().ToListAsync();

            return subCounties;
        }
        public async Task<List<Location>> GetLocations()
        {
            var locations = await _locationRepository.AllIncludingQueryable().ToListAsync();

            return locations;
        }
        public async Task<List<SubLocation>> GetSubLocations()
        {
            var subLocations = await _subLocationRepository.AllIncludingQueryable().ToListAsync();

            return subLocations;
        }
        public async Task<List<Village>> GetVillages()
        {
            var villages = await _villageRepository.AllIncludingQueryable().ToListAsync();

            return villages;
        }
        public async Task<List<SocialAssistanceProgram>> GetPrograms()
        {
            var programs = await _programRepository.AllIncludingQueryable().ToListAsync();

            return programs;
        }
    }
}
