﻿using iTut.Constants;
using iTut.Data;
using iTut.Models.Users;
using iTut.Models.Coordinator;
using iTut.Models.Parent;
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
        //adding search functionality
        
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

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            //if(Id == null || Id == 0)
            //{
            //    return NotFound();
            //}
            //var subjecct = _context.Subjects.Find(Id);
            //if(subjecct == null)
            //{
            //    return NotFound();
            //}
            Subject subject = _context.Subjects.FirstOrDefault(s => s.Id == Id);
            if (ModelState.IsValid)
            {
                _context.Subjects.Update(subject);
                _context.SaveChanges();
                return RedirectToAction("Subject");
            }
            return View();
            //Subject subject = _context.Subjects.FirstOrDefault(s => s.Id == Id);
            //if (subject != null)
            //{
            //    _context.Update(subject);
            //    _context.SaveChanges();
            //    return RedirectToAction("Edit");
            //}
          
            return View();
        }
        //edit
        [HttpPost]
        public async Task<IActionResult>Edit(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
            return RedirectToAction("Subject");
            //try
            //{
            //    Subject studentToUpdate = new Subject() { Id = Id };
            //    _context.Entry(studentToUpdate).State = EntityState.Modified;
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Edit));
            //}
            //catch (DbUpdateException /* ex */)
            //{
            //    //Log the error (uncomment ex variable name and write a log.)
            //    return RedirectToAction(nameof(Edit), new { Id = Id, saveChangesError = true });
            //}

            //var subject = _context.Subjects.Where(s => s.Id == Id).FirstOrDefault();

            //if (Id == null)
            //{
            //    return NotFound();
            //}

            //var subject = _context.Subjects.AsNoTracking().FirstOrDefault(s => s.Id == Id);

            //if (subject == null)
            //{
            //    return NotFound();
            //}
            //return View(subject);

        }


        //DELETE 
        public IActionResult Delete(string Id)
        {
            Subject subject = _context.Subjects.FirstOrDefault(s => s.Id == Id);
            if (subject != null)
            {
                _context.Remove(subject);
                _context.SaveChanges();
                return RedirectToAction("Subject");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            try
            {
                Subject studentToDelete = new Subject() { Id = Id };
                _context.Entry(studentToDelete).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { Id = Id, saveChangesError = true });
            }
        }

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
        //Create the feedback
        [HttpPost]
        public IActionResult Reports(Report model)
        {
            if (ModelState.IsValid)
            {
                var SubjectCoordinator = _context.SubjectCoordinator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();
                var report = new Report
                {

                };
                _context.Add(report);

                _logger.LogInformation("Subject was created!");
                return RedirectToAction(nameof(Subject));
            }
            return View(model);
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


        //GET FEEDBACK
        public IActionResult ViewFeedback()
        {
           return View(_context.Feedbacks.ToList());            
        }

        [HttpGet]
        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Feedback(Feedback model)
        {
            if (ModelState.IsValid)
            {
                var SubjectCoordinator = _context.SubjectCoordinator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();
                var feedback = new Feedback
                {
                    Id = model.Id,
                    //UserId=model.UserId,
                    FeedbackContent = model.FeedbackContent
                };
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Feedback was created!");
                return RedirectToAction("Feedback");
            }
            return View(model);
        }
        public IActionResult Educator()
        {
            return View();
        }
       
        //Assign Subjects
        public IActionResult AssignSubjects()
        {
            return View();
        }
    }
}