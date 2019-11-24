using DataModel;
using DB_Library.UnitOfWork;
using QuizzApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuizzApp.Controllers
{
    public class QuizController : Controller
    {
        //
        private IUnitOfWork _unitOfWork;

        public QuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: /Quizz/

        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Certification(string SearchText)
        {
           
            // get the list of subjects from quizz subject repository.
           // var certificationLis = (await _unitOfWork.Repository<QuizzSubject>().Get(includes: s => s.QuizzMapings));
            var certificationList =  (await _unitOfWork.Repository<QuizzSubject>()
                                            .Get(s=>s.QuizzMapings.Count() !=0
                                                 && string.IsNullOrEmpty(SearchText) ? true : s.Qs_Subject.ToUpper().Contains(SearchText.ToUpper()) 
                                                ,includes:s=>s.QuizzMapings)
                                               ).ToList()
                                                .Select(s => new CertificationModel
                                            {
                                                Id = s.Qs_Id,
                                                Subject = s.Qs_Subject,
                                                Description = s.QuizzMapings.FirstOrDefault().Qm_Description
                                            });
            ViewBag.Searchtext = SearchText;
            return View(certificationList.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> SelectExam(int id )
        {
            var selectExamModel = (await _unitOfWork.Repository<QuizzSubject>()
                                    .GetById(id)).QuizzMapings.Select(s => new SelectExamModel
                                    {
                                        Description=s.Qm_Description,
                                        ExamLevel=s.QuizzLevel.Ql_Type,
                                        ExamID=s.Qm_Id,
                                        ExamLevelId=s.QuizzLevel.Ql_Id
                                    }).ToList();

            return View(selectExamModel);
        }
        [HttpGet]
        public async Task<ActionResult> Exam(int? SelectExamRadio)
        {
          //  ExamModel examModel=new ExamModel();
            if(SelectExamRadio.Equals(null))
                return RedirectToAction("Certification");
            // bind the view model ofr exam action.
            ViewBag.ExamId = SelectExamRadio;
            var examModel = (await _unitOfWork.Repository<QuizzMaping>()
                             .GetById(SelectExamRadio)).QuizzQustionMapings
                             .GroupBy(g => g.QuizzQuestionMaster).Select(s => new ExamModel
                             {
                                 QustionId = s.Key.Qq_Id,
                                 QustionText = s.Key.Qq_Question,
                                 options = s.Key.QuizzQustionMapings.Select(qm => new ExamOptions {                                  
                                 OptionId=qm.QuizzQustionsOption.Qo_Id,
                                 OptionText=qm.QuizzQustionsOption.Qo_AnswerText                                 
                                 }).ToList()
                             }).ToList();

            return View("Exam", examModel);
        }
        [HttpPost]
        public  ActionResult Exam(int ExamId, List<ExamModel> examModel)
        {
            int candidateId = 1;
            // bind the properties to candidate repository model.
            var candidaeRepository = new CandidateRepository
            {
                Cq_CandidateId = candidateId,
                Cq_QuizzId = ExamId,
                Cq_Date = DateTime.Now,
                CandidateAnswers = examModel.Select(s => new CandidateAnswer 
                {                
                    Ca_QustionId=s.QustionId,
                    Ca_SelectedOption=s.SelectedOption                
                }).ToList()
            };
            //insert data in database.            
             _unitOfWork.Repository<CandidateRepository>().Insert(candidaeRepository);
           _unitOfWork.Save();

           return RedirectToAction("ReviewAnswers", new { RepositoryId = candidaeRepository.Cq_ID });
        }

        [HttpGet]
        public async Task<ActionResult> ReviewAnswers(int RepositoryId)
        {
            //get the user answers from database.
            var CandidateAnswer = (await _unitOfWork.ScoreCardRepository().GetById(RepositoryId))
                                    .GroupBy(g => new{g.QustionId,g.QuestionText})
                                    .Select(s => new ReviewAnswersModel 
                                    { 
                                        QustionId=s.Key.QustionId,
                                        QustionText=s.Key.QuestionText,
                                        SelectedAnswerId=s.FirstOrDefault().selectedOption,
                                        Options = s.Select(o => new ReviewAnswersOption
                                        {
                                            OptionId=o.AnswerId,
                                            IsAnswer=(bool)o.IsAnswer,
                                            OptionText=o.AnswerText                                        
                                        }).ToList()
                                    });
            ViewBag.Marks = CandidateAnswer.Count(s => s.SelectedAnswerId == s.Options.FirstOrDefault(f => f.IsAnswer == true).OptionId);
            return View(CandidateAnswer);
        }

    }
}
