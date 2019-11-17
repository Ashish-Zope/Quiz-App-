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

        [ActionName("Certification")]
        [HttpGet]
        public async Task<ActionResult> Certification()
        {
            // get the list of subjects from quizz subject repository.
           // var certificationLis = (await _unitOfWork.Repository<QuizzSubject>().Get(includes: s => s.QuizzMapings));
            var certificationList =  (await _unitOfWork.Repository<QuizzSubject>().Get(s=>s.QuizzMapings.Count() !=0,includes:s=>s.QuizzMapings)).ToList()
                                                .Select(s => new CertificationModel
                                            {
                                                Id = s.Qs_Id,
                                                Subject = s.Qs_Subject,
                                                Description = s.QuizzMapings.FirstOrDefault().Qm_Description
                                            });
         
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

        public async Task<ActionResult> Exam(int ? SelectExamRadio)
        {



            return View();
        }



    }
}
