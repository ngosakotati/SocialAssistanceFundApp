using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialAssistanceFundApp.Models.ApplicantInfo;
using SocialAssistanceFundApp.Models.ApplicationInfo;
using SocialAssistanceFundApp.Models.ViewModels;
using SocialAssistanceFundApp.Services;

namespace SocialAssistanceFundApp.Controllers
{
    public class ApplicationsController(ApplicationMgtService appMgtService, IMapper mapper) : Controller
    {
        private ApplicationMgtService _appMgtService = appMgtService;
        private readonly IMapper _mapper = mapper;

        public async Task<IActionResult> IndexAsync()
        {
            var applications = await _appMgtService.GetAllApplicationsAsync();

            var applicationViewModels = _mapper.Map<List<ApplicationViewModel>>(applications);

            return View(applicationViewModels);
        }

        public async Task<IActionResult> CreateApplication()
        {
            await LoadCreateApplicationViewBags();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApplication(CreateApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCreateApplicationViewBags();
                return View(model);
            }

            // Map view model to Applicant model
            var applicant = _mapper.Map<Applicant>(model);

            // Save Applicant first to generate ID
            var createdApplicant = await _appMgtService.CreateApplicant(applicant);

            // Create Application
            var application = new Application
            {
                ApplicantId = createdApplicant.Id,
                SocialAssistanceProgramId = model.SocialAssistanceProgramId,
                ApplicationDate = model.ApplicationDate
            };

            // Create the application and save it to the db
            await _appMgtService.CreateApplication(application);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditApplication(int id)
        {
            // Get application
            var application = await _appMgtService.GetApplicationById(id);
            if (application == null)
            {
                return NotFound();
            }

            var applicationViewModel = _mapper.Map<CreateApplicationViewModel>(application);

            await LoadCreateApplicationViewBags();

            return View(applicationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditApplication(int id, CreateApplicationViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await LoadCreateApplicationViewBags();
                return View(model);
            }

            var application = _mapper.Map<Application>(model);

            await _appMgtService.UpdateApplication(application);

            return RedirectToAction("Index");;
        }

        private async Task LoadCreateApplicationViewBags()
        {
            ViewBag.SexList = new SelectList(await _appMgtService.GetSexes(), "Id", "Name");
            ViewBag.MaritalStatusList = new SelectList(await _appMgtService.GetMaritalStatuses(), "Id", "Status");
            ViewBag.Counties = new SelectList(await _appMgtService.GetCounties(), "Id", "Name");
            ViewBag.SubCounties = new SelectList(await _appMgtService.GetSubCounties(), "Id", "Name");
            ViewBag.Locations = new SelectList(await _appMgtService.GetLocations(), "Id", "Name");
            ViewBag.SubLocations = new SelectList(await _appMgtService.GetSubLocations(), "Id", "Name");
            ViewBag.Villages = new SelectList(await _appMgtService.GetVillages(), "Id", "Name");
            ViewBag.ProgramsList = new SelectList(await _appMgtService.GetPrograms(), "Id", "Name");
        }


    }
}
