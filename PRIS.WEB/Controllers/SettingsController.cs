﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
using PRIS.WEB.ViewModels.ModuleViewModels;
using PRIS.WEB.ViewModels.TaskGroupViewModel;
using System;
using System.Linq;

namespace PRIS.WEB.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ApplicationDbContext _context;

        public SettingsController(ILogger<SettingsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Settings()
        {
            return RedirectToAction("City");
        }

        #region City/Create/Delete

        public IActionResult City()
        {
            if (TempData["TestIsAddedToTheCityErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["TestIsAddedToTheCityErrorMessage"].ToString());
            }
            return View(_context.Cities.ToList());
        }

        [HttpGet]
        public IActionResult CityModalPartial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CityModalPartial(AddCityViewModel city)
        {
            var check = _context.Cities.Any(x => x.CityName == city.CityName);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Toks miestas jau yra sukurtas");
            }

            if (ModelState.IsValid)
            {
                var newRecord = new City() { CityName = city.CityName };
                if (newRecord != null)
                {
                    _context.Cities.Add(newRecord);
                    _context.SaveChanges();
                }
                return RedirectToAction("City");
            }
            return View();
        }

        public IActionResult CityDelete(int id)
        {
            var testConnected = _context.Test.Any(x => x.City.CityId == id);

            if (testConnected)
            {
                TempData["TestIsAddedToTheCityErrorMessage"] = "Miesto trinti negalima - jam jau yra priskirtas testas.";
                return RedirectToAction("City");
            }
            else if (ModelState.IsValid)
            {
                var data = _context.Cities.SingleOrDefault(x => x.CityId == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("City");
            }
            return RedirectToAction("City");
        }

        #endregion City/Create/Delete

        #region Module

        public IActionResult Module()
        {
            if (TempData["IsTestUsedInCandidateModuleTableErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["IsTestUsedInCandidateModuleTableErrorMessage"].ToString());
            }
            return View("Module", _context.Modules.OrderBy(m => m.ModuleName).ToList());
        }

        #endregion Module

        #region Module/Create

        public IActionResult ModuleCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModuleCreate(AddModuleViewModel module)
        {
            var check = _context.Modules.Any(m => m.ModuleName == module.ModuleName);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Tokia mokymų programa jau yra sukurta");
                return View();
            }

            if (ModelState.IsValid)
            {
                var newModule = new Module() { ModuleName = module.ModuleName };
                if (newModule != null)
                {
                    _context.Modules.Add(newModule);
                    _context.SaveChanges();
                }
                return RedirectToAction("Module");
            }
            return View();
        }

        #endregion Module/Create

        #region Module/Delete

        public IActionResult ModuleDelete(int id)
        {
            var testConnected = _context.CandidateModules.Any(x => x.Module.ModuleID == id);

            if (testConnected)
            {
                TempData["IsTestUsedInCandidateModuleTableErrorMessage"] = "Negalima trinti mokymo programos, nes ji yra priskirta prie kandidato!";
                return RedirectToAction("Module");
            }
            else if (ModelState.IsValid)
            {
                var data = _context.Modules.SingleOrDefault(x => x.ModuleID == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("Module");
            }
            return RedirectToAction("Module");
        }

        #endregion Module/Delete

        #region ResultLimits/Create

        public IActionResult ResultLimits_View()
        {
            return View(_context.ResultLimits.ToList());
        }

        [HttpGet]
        public IActionResult ResultLimits_Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResultLimits_Create(AddResultLimitsViewModel limits)
        {
            //TODO rezultatu limitai susije su testo sablonu

            var sumTestResults = limits.Task1 + limits.Task2 + limits.Task3 + limits.Task4 + limits.Task5 + limits.Task6 + limits.Task7 + limits.Task8 + limits.Task9 + limits.Task10;
            if (sumTestResults != limits.ResultSumMax)
            {
                ModelState.AddModelError(string.Empty, "Testo balų suma turi atitikti bendrą testo balą. Pasitikrinkite įvestis, jų sumą ir bendrą testo balą.");
            }
            if (ModelState.IsValid)
            {
                string timeStamp = GetTimestamp(DateTime.Now);
                var newRecord = new ResultLimits() { ResultLimitsId = limits.ResultLimitsId, DateLimitSet = timeStamp, Task1 = limits.Task1, Task2 = limits.Task2, Task3 = limits.Task3, Task4 = limits.Task4, Task5 = limits.Task5, Task6 = limits.Task6, Task7 = limits.Task7, Task8 = limits.Task8, Task9 = limits.Task9, Task10 = limits.Task10, ResultSumMax = limits.ResultSumMax };
                if (newRecord != null)
                {
                    _context.ResultLimits.Add(newRecord);
                    _context.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Įveskite teisingus duomenis.");
                }
                return RedirectToAction("ResultLimits_View");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Pasitikrinkite, ar įvedėte visus duomenis.");
            }
            return View();
        }

        private string GetTimestamp(DateTime date)
        {
            return date.Date.ToString("yyyy/MM/dd");
        }

        //public IActionResult LimitsDelete(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var data = _context.ResultLimits.SingleOrDefault(x => x.ResultLimitsId == id);
        //        if (data != null)
        //        {
        //            _context.Remove(data);
        //            _context.SaveChanges();
        //        }
        //        return RedirectToAction("ResultLimits_View");
        //    }
        //    return RedirectToAction("ResultLimits_View");
        //}

        #endregion ResultLimits/Create

        #region TaskGroup

        //public IActionResult TaskGroup()
        //{
        //    var taskGroupModel = _context.TaskGroups
        //        .ProjectTo<AddTaskGroupViewModel>(_mapper.ConfigurationProvider).ToList();

        //    return View(taskGroupModel);
        //}

        public IActionResult TaskGroup()
        {
            if (TempData["IsTestUsedInTaskGroupModuleTableErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["IsTestUsedInTaskGroupModuleTableErrorMessage"].ToString());
            }
            return View("TaskGroup", _context.TaskGroups.OrderBy(m => m.TaskGroupName).ToList());
        }

        #endregion

        #region TaskGroup/Create

        public IActionResult TaskGroupCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TaskGroupCreate(AddTaskGroupViewModel addTaskGroup)
        {
            var check = _context.TaskGroups.Any(t => t.TaskGroupName == addTaskGroup.TaskGroupName);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Tokia užduočių grupė jau yra sukurta");
                return View();
            }

            if (ModelState.IsValid)
            {
                var newTaskGroup = new TaskGroup() { TaskGroupName = addTaskGroup.TaskGroupName, TaskGroupCount = addTaskGroup.TaskGroupCount };
                if (newTaskGroup != null)
                {
                    _context.TaskGroups.Add(newTaskGroup);
                    _context.SaveChanges();
                }
                return RedirectToAction("TaskGroup");
            }
            return View();
        }

        #endregion

        #region TaskGroup/Delete

        public IActionResult TaskGroupDelete(int id)
        {
            var testConnected = _context.InterviewTasks.Any(x => x.TaskGroup.TaskGroupID == id);

            if (testConnected)
            {
                TempData["IsTestUsedInInterviewTaskModuleTableErrorMessage"] = "Negalima trinti užduočių grupės, nes ji yra susieta su pokalbio užduotimis!";
                return RedirectToAction("TaskGroup");
            }
            else if (ModelState.IsValid)
            {
                var data = _context.TaskGroups.SingleOrDefault(t => t.TaskGroupID == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("TaskGroup");
            }
            return RedirectToAction("TaskGroup");
        }

        #endregion --- TaskGroup/Delete ---
    }
}