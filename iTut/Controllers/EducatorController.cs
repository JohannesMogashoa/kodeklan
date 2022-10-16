using iTut.Constants;
using iTut.Data;
using iTut.Models.Coordinator;
using iTut.Models.Users;
using iTut.Models.UploadFiles;
using iTut.Models.ViewModels.Educator;
using iTut.Models.Edu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace iTut.Controllers
{
    [Authorize(Roles = RoleConstants.Educator)]
    public class EducatorController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EducatorController> _logger;

        public EducatorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<EducatorController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public ActionResult Index()
        {
            var educator = _context.Educator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();

            var viewModel = new EducatorIndexViewModel
            {
                Educator = educator,
            };

            return View(viewModel);
        }

        public IActionResult CreateTask()
        {
            return View();
        }

        #region Categories
        //Categories are renamed to topics 
        public IActionResult Categories()
        {
            //return View(await _context.Categories.Where(c => c.EducatorID == _userManager.GetUserId(User)).ToListAsync());
            return View(_context.Topics.ToList());

        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCategory(Topic model)
        {
            if (ModelState.IsValid)
            {
                var educator = _context.Educator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();

                var category = new Topic
                {
                    EducatorID = educator.Id,
                    TopicName = model.TopicName,
                    Status = Topic.TopicStatus.Active,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,

                };
                _context.Add(category);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Categoy created!");
                return RedirectToAction(nameof(Categories));
            }
            return View(model);
        }
#endregion
        public IActionResult CreateQuiz()
        {
            return View();
        }

        #region UploadedFiles
        private async Task<FileUploadViewModel> LoadAllFiles()
        {
            
          
            var viewModel = new FileUploadViewModel();
            viewModel.FilesOnDatabase = await _context.FilesOnDatabase.ToListAsync();
            viewModel.subjects=  _context.Subjects.ToList();
            viewModel.topics= await _context.Topics.ToListAsync();
            
            
            //  string grades = new List<Grade>;

            // model.Jobs.Add(new SelectListItem() { Text = "Email", Value = "1", Selected = false });
            //viewModel.subjects= new List<Subject>();
            //viewModel.subjects.Add(new Subject());

            return viewModel;
        }
        public async Task<IActionResult> UploadFile()
        {
           
            var fileuploadViewModel = await LoadAllFiles();
            ViewBag.topics = _context.Topics.ToList();
            ViewBag.Message = TempData["Message"];
            return View(fileuploadViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files, string description,Grade grade)
        {
            foreach (var file in files)
            {
             
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var subject = _context.Subjects.FirstOrDefault();
                var topic = _context.Topics.Where(t => t.Status == Topic.TopicStatus.Active).FirstOrDefault();
                var extension = Path.GetExtension(file.FileName);


                var fileModel = new FileOnDatabase
                {
                    CreatedOn = DateTime.UtcNow,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName,
                    Description =description,
                    SubjectID =subject.Id,
                    TopicID = topic.TopicId,
                    Grade= grade,
                    
                };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    fileModel.Data = dataStream.ToArray();
                }
                _context.FilesOnDatabase.Add(fileModel);
                _context.SaveChanges();
            }
            TempData["Message"] = "File successfully uploaded";
            return RedirectToAction("UploadFile");
        }
        public async Task<IActionResult> DownloadFileFromDatabase(string id)
        {
            var file = await _context.FilesOnDatabase.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (file == null) return null;
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }
        public async Task<IActionResult> DeleteFileFromDatabase(string id)
        {
            var file = await _context.FilesOnDatabase.Where(x => x.ID == id).FirstOrDefaultAsync();
            _context.FilesOnDatabase.Remove(file);
            _context.SaveChanges();
            TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from the Files.";
            return RedirectToAction("UploadFile");
        }
        #endregion
    }
}
