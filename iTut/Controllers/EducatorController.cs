
using iTut.Constants;
using iTut.Data;
using iTut.Models.Coordinator;
using iTut.Models.Users;
using iTut.Models.UploadFiles;
using iTut.Models.Quiz;
using iTut.Models.Marks;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using iTut.Models.Parent;
using System.Runtime.Intrinsics.X86;
using System.Net.WebSockets;
using iTut.Models.Shared;
using PagedList;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        public async Task <IActionResult> Categories()
        {
            var educator = _context.Educator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            
            var categories = await _context.Topics.Where(tE=>tE.EducatorID==educator.Id).Include(t => t.Educator).ToListAsync();

            return View(categories);

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

        public async Task<IActionResult> DeleteCategory(string? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

         
            var categories = await _context.Topics.Where(t=>t.TopicId==Id).Include(t => t.Educator).FirstOrDefaultAsync();
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }
        // POST: /Movies/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed2(string Id)
        {
            Topic category = await _context.Topics.FindAsync(Id);

            _context.Topics.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Categories));
        }
        #endregion


        #region CreatQuiz
        public IActionResult CreateQuiz()
        {
            ViewBag.topics = _context.Topics.ToList();
            ViewBag.subjects= _context.Subjects.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuiz(Quiz model)
        {
            if (ModelState.IsValid)
            {
                var educator = _context.Educator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();

                var quiz = new Quiz
                {
                    EducatorID = educator.Id,
                    TopicId = model.TopicId,
                    SubjectID = model.SubjectID,
                    QuizTittle= model.QuizTittle,
                    QuizDescription = model.QuizDescription,
                    Status = Quiz.quizStatus.Active,
                    CreatedAt = DateTime.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Grade=model.Grade,
                };
                _context.Add(quiz);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Quiz id= {quiz.QuizId}, has beeen created!");
                return RedirectToAction(nameof(Questions));

            }

            return View(model);

        }
        public IActionResult Questions()
        {
            QuizViewModel quizViewModel = new QuizViewModel();

            quizViewModel.ListOfQuizzes=( from quiz in _context.Quizzes 
                               select new SelectListItem()
                               {
                                   Value= quiz.QuizId.ToString(),
                                   Text=quiz.QuizTittle
                               }
                               
                               ).ToList();

            return View(quizViewModel);

        }

        [HttpPost]
        public JsonResult Questions(QuestionOptionViewModel questionOption)
        {

            Question question = new Question(); 
            question.QuestionName= questionOption.QuestionName;
            question.QuizID = questionOption.QuizId;

            _context.Questions.Add(question);
            _context.SaveChanges();

            string questionID= question.QuestionID;

            foreach(var item in questionOption.ListOfOptions)
            {
                Option option= new Option();

                option.OptionName= item;
                option.QuestionID= questionID;
                
                _context.Options.Add(option);
                _context.SaveChanges();
                    
            }

            Answer answer = new Answer();
            answer.AnswerText= questionOption.AnswerText;
            answer.QuestionID = questionID;
            _context.Answers.Add(answer);
            _context.SaveChanges();

            return Json(data: new { mesage = "Data is Successfully Loaded", success=true}, new Newtonsoft.Json.JsonSerializerSettings());
        }

#endregion


        #region UploadedFiles
         private async Task<FileUploadViewModel> LoadAllFiles()
         {
            var educator = _context.Educator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();

            var viewModel = new FileUploadViewModel();
               viewModel.FilesOnDatabase = await _context.FilesOnDatabase.Where(f=>f.UploadedBy==educator.Id).Include(f=>f.Educator).ToListAsync();
               viewModel.subjects=  _context.Subjects.ToList();
               viewModel.topics= await _context.Topics.ToListAsync();
            
            
        

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
                var educator = _context.Educator.Where(e => e.UserId == _userManager.GetUserId(User)).FirstOrDefault();

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
                    UploadedBy=educator.Id,
                    
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
            TempData["Message"] = $"Removed {file.Description + file.Name} successfully from the Files.";
            return RedirectToAction("UploadFile");
        }
        #endregion

        #region students
        public async Task<IActionResult> Students(string sortOrder, string currentFilter,int? pageNumber, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["GradeSortParm"] = sortOrder == "Grade" ? "Grade" : "Grade_desc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.Students
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Grade":
                    students = students.OrderBy(s => s.Grade);
                    break;
                case "Grade_desc":
                    students = students.OrderByDescending(s => s.Grade);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<StudentUser>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        public IActionResult StudentDetails(string Id)
        {
            
            if (Id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Where(s => s.Id == Id).ToList();

            StudentViewModel model = new StudentViewModel()
            {
                students = student


            };

            return View(model);
        }

        #endregion

        #region Marks
        public async Task<ActionResult> LoadMarks(string sortOrder, string currentFilter, int? pageNumber, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["GradeSortParm"] = sortOrder == "Grade" ? "Grade" : "Grade_desc";
            ViewData["AverageSortParm"] = sortOrder == "Average" ? "Average" : "Average_desc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var marks = from m in _context.Marks
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                marks= marks.Where(s => s.students.FirstName.Contains(searchString)
                                       || s.students.LastName.Contains(searchString) || s.outcome.Contains(searchString) );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    marks = marks.OrderByDescending(s => s.students.LastName);
                    break;
                case "Grade":
                     marks = marks.OrderBy(s => s.students.Grade);
                    break;
                case "Grade_desc":
                     marks = marks.OrderByDescending(s => s.students.Grade);
                    break;
                case "Average":
                    marks = marks.OrderBy(s => s.avg);
                    break;
                case "Average_desc":
                    marks = marks.OrderByDescending(s => s.avg);
                    break;
              
                default:
                    marks = marks.OrderBy(s => s.students.LastName);
                    break;
            }

            int pageSize = 3;
            //var marks = await _context.Marks.Include(m=>m.subject).Include(ms=>ms.students).ToListAsync();




            return View(await PaginatedList<Mark>.CreateAsync(marks.Include(m => m.subject).Include(ms => ms.students).AsNoTracking(), pageNumber ?? 1, pageSize));
       
        }

        public ActionResult EditMarks(string Id)
        {   
            var mark= _context.Marks.Where(m=>m.Id == Id).Include(m=>m.students).Include(s=>s.subject).FirstOrDefault();
           
            return View(mark);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>UpdateMarks(Mark model)
        {
             model.Total = model.Term1 + model.Term2 + model.Term3 + model.Term4;

            model.avg = model.Total / 4;

            if (model.avg >= 50 && model.avg < 80)
            {

                model.outcome = "pass";
            }
            else if (model.avg >= 80)
            {
                model.outcome = "Pass with Distinction";
            }
            else if (model.avg < 50)
            {
                model.outcome = "Fail";
            }

            var marks = _context.Marks.Where(m => m.Id == model.Id).FirstOrDefault();

                if (marks != null)
                {
                    marks.Term1 = model.Term1;
                    marks.Term2 = model.Term2;
                    marks.Term3 = model.Term3;
                    marks.Term4 = model.Term4;
                    marks.avg = model.avg;
                    marks.Total = model.Total;
                    marks.outcome = model.outcome;
                   
                    _context.Marks.Update(marks);
                    await _context.SaveChangesAsync();
                }
            return RedirectToAction(nameof(LoadMarks));

            
        }

        public async Task<IActionResult> DeleteMark(string? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks.Where(m => m.Id == Id).Include(m => m.students).Include(s => s.subject).FirstOrDefaultAsync();

            if (marks==null)
            {
                return NotFound();
            }
            return View(marks);
        }
        // POST: /Movies/Delete/5
        [HttpPost, ActionName("DeleteMark")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Id)
        {
            Mark mark = await _context.Marks.FindAsync(Id);
            _context.Marks.Remove(mark);
            _context.SaveChanges();
            return RedirectToAction(nameof(LoadMarks));
        }

        public async Task <IActionResult> StudentMarks()
        {

            ViewBag.Students= _context.Students.ToList();
            
            ViewBag.subjects = _context.Subjects.ToList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMarks(Mark model)
        {
            
            model.Total= model.Term1 + model.Term2 + model.Term3 + model.Term4;

            model.avg = model.Total / 4;

            if (model.avg >= 50 && model.avg <80)
            {

                model.outcome = "pass";
            }
           else if (model.avg >= 80)
            {
                model.outcome = "Pass with Distinction";
            }
            else if (model.avg < 50)
            {
                model.outcome = "Fail";
            }

            if (ModelState.IsValid)
            {
                var mark = new Mark
                {
                    StudentID = model.StudentID,
                    SubjID=model.SubjID,
                    Term1=model.Term1,
                    Term2=model.Term2,
                    Term3=model.Term3,
                    Term4=model.Term4,
                    avg=model.avg,
                    Total=model.Total,
                    outcome=model.outcome,
                };
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(StudentMarks));
            }
            return View(model);
        }


        public IActionResult MarksDetails(string Id)
        {
            var mark = _context.Marks.Where(m => m.Id == Id).Include(m => m.students).Include(s => s.subject).FirstOrDefault();
            if (Id == null)
            {
                return NotFound();
            }

            var markList = _context.Marks.Where(m => m.Id == Id).ToList();

             studentMarksViewModel model =new studentMarksViewModel()
            {
               marks=markList


            };

            return View(model);
        }

        private bool MarksExists(string Id)
        {
            return _context.Marks.Any(m => m.Id == Id);
        }
        #endregion

        #region Post


        [Route("/Educator/LikePost/{id}")]
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LikePost([FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                var _post = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
                if (_post != null)
                {
                    _post.Likes = _post.Likes++;
                    _post.UpdatedAt = DateTime.Now;
                    _context.Update(_post);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Post, id: {_post.Id}, updated");
                    return RedirectToAction(nameof(Index));
                }
            }
            return View("Error");
        }

        // GET: Timeline Post
        [HttpGet("/Educator/Post/{id}")]
        public IActionResult Post([FromRoute] string id)
        {
            var post = _context.Posts.Where(p => p.Id.Equals(id)).Include(p => p.Comments).FirstOrDefault();

            ViewBag.Post = post;

            return View();
        }

        // POST: Comment on Timeline Post
        [HttpPost("/Educator/Post/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommentOnPost([FromRoute] string id, PostComment model)
        {
            var post = _context.Posts.Where(p => p.Id.Equals(id)).Include(p => p.Comments).FirstOrDefault();
            var userId = _context.Users.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault().Id;
            if (post != null && !post.Archived)
            {
                if (ModelState.IsValid)
                {
                    var comment = new PostComment
                    {
                        UserId = userId,
                        CommentContent = model.CommentContent,
                        Post = post,
                        CreatedAt = DateTime.Now,
                    };
                    _context.Add(comment);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Comment, id: {comment.Id}, created on post: {post.Id}");
                    return Redirect($"/Educator/Post/{id}");
                }
                return View("Error");
            }
            return NotFound();
        }
        #endregion

       public IActionResult Feedbacks()
       {


            var feedback = _context.Feedbacks.ToList();

            FeedbackViewModel feedbackView = new FeedbackViewModel()
            {
                feedbacks = feedback
            };

            return View(feedbackView);

       }
    }    

}

