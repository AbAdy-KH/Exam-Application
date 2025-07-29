using AutoMapper;
using ExamApp.Mvc.Contracts;
using ExamApp.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ExamApp.Mvc.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examSrv;
        public ExamController(IExamService examSrv)
        {
            _examSrv = examSrv;
        }

        
        public async Task<ActionResult> Index()
        {
            var response = await _examSrv.GetAll();



            return View(response);
        }



        // GET: ExamController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await _examSrv.Get(id);

            return View(response);
        }


        // GET: ExamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateExamVM obj)
        {
            try
            {
                await _examSrv.Create(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _examSrv.Get(id);

            return View(response);
        }

        // POST: ExamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ExamVM obj)
        {
            try
            {
                await _examSrv.Update(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: ExamController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ExamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _examSrv.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> TakeExam(int id)
        {
            var response = await _examSrv.GetWholeExam(id);

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitExam(SubmitAnswersVM vm)
        {
            try
            {
                await _examSrv.SubmitExam(vm);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
