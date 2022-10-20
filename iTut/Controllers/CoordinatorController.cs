﻿using iTut.Constants;
using iTut.Data;
using iTut.Models.Users;
using iTut.Models.Coordinator;
using iTut.Models.Parent;
using iTut.Models.Edu;
using iTut.Models.ViewModels.Coordinator;
using iTut.Models.ViewModels.Educator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
//using AspNetCore;

namespace iTut.Controllers
{
    [Authorize(Roles = RoleConstants.SubjectCoordinator)]
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CoordinatorController> _logger;
        private ApplicationUser user;

        public CoordinatorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<CoordinatorController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            //_queue = queue;
        }

        public ActionResult Index()
        {
            var SubjectCoordinator = _context.SubjectCoordinator.Where(c => c.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            var viewModel = new CoordinatorIndexViewModel
            {
                SubjectCoordinator = SubjectCoordinator,
            };
            return View(viewModel);
        }

       
        public IActionResult Feedback(string Id)
        {
            return View(_context.Feedbacks.ToList());
            // return View();
        }

        [HttpGet]
        public IActionResult CreateFeedback()
        {
           // ViewBag.Educator = new SelectList(_context.Educator, "Id", "EmailAddress");
          //  ViewBag.Educator = new SelectList(_context.Educator, "Id", "EmailAddress");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeedback(Feedback model)
        {
            if (ModelState.IsValid)
            {
                var SubjectCoordinator = _context.SubjectCoordinator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();
                var feedback = new Feedback
                {
                    Id = model.Id,
                  //  EducatorId = model.EducatorId,
                    FeedbackContent = model.FeedbackContent,
                    CreateAt = DateTime.Now,
                };
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Feedback was created!");
                return RedirectToAction("Feedback");
            }
           // ViewBag.Educator = new SelectList(_context.Educator, "Id", "EmailAddress", "Id");
            return View(model);
        }

        public IActionResult Subject(string Id)
        {

            return View(_context.Subjects.ToList());
        }
       
        //complaint
        public IActionResult Complaint()
        {
            return View(_context.Complaints.ToList());
            //return View (_context.Complaints.)
        }

        public IActionResult CreateASubject()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateASubject(Subject model)
        {
            if (ModelState.IsValid)
            {
                var SubjectCoordinator = _context.SubjectCoordinator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();

                var subject = new Subject
                {
                    Id = model.Id,
                    SubjectName = model.SubjectName,
                    SubjectDescr = model.SubjectDescr,
                   // Status = model.Statuses.Active,
                    Grade = model.Grade,    
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now,

                };
                _context.Add(subject);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Subject was created!");
                return RedirectToAction("Subject");
            }
            return View(model);
        }



        //GET-Update

        public IActionResult Edit(string Id)
        {
            if (Id == null/* || Id == 0*/)
            {
                return NotFound();
            }

            var subject = _context.Subjects.Find(Id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
            return RedirectToAction("Subject");
        }


        //DELETE
        public IActionResult Delete(string Id)
        {
            if (Id == null/* || Id == 0*/)
            {
                return NotFound();
            }

            var subject = _context.Subjects.Find(Id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Subject subject)
        {
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //public IActionResult Delete(string Id)
        //{
        //    if (Id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subject = _context.Subjects.Find(Id);
        //    if(subject == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(subject);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(string Id)
        //{
        //    var subject = _context.Subjects.Find(Id);
        //    //if(subject == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    _context.Subjects.Remove(subject);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(subject));
        //   // return View(subject);
        //}

        //details
        public IActionResult Details(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var subject = _context.Subjects.AsNoTracking().FirstOrDefault(s => s.Id == Id);
            if(subject == null)
            {
                return NotFound();
            }
            return View(subject);
           // return RedirectToAction("Details");
          // return View(Details);
        }
       

        //complaint details
        public IActionResult ComplaintDetails(string Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var complaint = _context.Complaints.AsNoTracking().FirstOrDefault(c => c.Id == Id);
            if(complaint == null)
            {
                return NotFound();
            }
            return View(complaint);
         
        }
        //return here after 
        public IActionResult Reports()
        {
            return View();

        }
        
        /*//GET FEEDBACK
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Feedback(Feedback model)
        {
            if (ModelState.IsValid)
            {
                var SubjectCoordinator = _context.SubjectCoordinator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();
                var feedback = new Feedback
                {
                    Id=model.Id,
                    //UserId=model.UserId,
                    FeedbackContent = model.FeedbackContent
                };
                _context.Add(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Feedback was created!");
                return RedirectToAction("ViewFeedback");
            }
            return View(model);
        }*/


        ////GET FEEDBACK
        //public IActionResult ViewFeedback()
        //{
        //   return View(_context.Feedbacks.ToList());            
        //}

    
        //Assign Subjects
        //getting the subjects 
        public IActionResult AssignSubjects()
        {
            ViewBag.Subject = new SelectList(_context.Subjects, "Id", "SubjectName");
          //  ViewBag.Grade = new SelectList(_context.Grades, "Id", "Grade");
            ViewBag.Educator = new SelectList(_context.Educator, "Id", "EmailAddress");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AssignSubjects(SubjectEducator subjectEducator)
        {

            if (ModelState.IsValid)
            {
              
                _context.Add(subjectEducator);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Subject was created!");
                return RedirectToAction("AssignedSubjects");
            }
            ViewBag.Subject = new SelectList(_context.Subjects, "Id", "SubjectName", "Id");
           // ViewBag.Grade = new SelectList(_context.Grades, "Id", "Grade");
            ViewBag.Educator = new SelectList(_context.Educator, "Id", "EmailAddress", "Id");
            return View(subjectEducator);
        }
        //This is where I can view who's assigned to what
        public IActionResult AssignedSubjects()
        {
            return View();
        }


        ////Archived / Recover deleted subjects
        //public IActionResult DeletedRecords( )
        //{
        //    var deletedRecords = _context.Subjects.Where(s => s.RecStatus == 'D').ToList();
        //    return View(deletedRecords);
        //}
        //public async Task<IActionResult> Recover(string Id)
        //{
        //    var deletedRecord = _context.Subjects.FirstOrDefault(s=> s.Id==Id);
        //    deletedRecord.RecStatus = 'A';

        //    _context.Subjects.Update(deletedRecord);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(deletedRecord));
        //}
    }
}