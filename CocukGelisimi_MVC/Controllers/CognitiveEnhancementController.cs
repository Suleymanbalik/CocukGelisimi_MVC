using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CocukGelisimi_MVC.Models.Entity;
using CocukGelisimi_MVC.Models.ViewModels;

namespace CocukGelisimi_MVC.Controllers
{
    public class CognitiveEnhancementController : Controller
    {

        Cocuk_Gelisimi_DbEntities1 db = new Cocuk_Gelisimi_DbEntities1 ();
        // GET: CognitiveEnhancement
        public ActionResult Index()
        {
            var values = db.Table_Student.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCognitiveData(int? id)
        {
            if (!id.HasValue) return RedirectToAction("index");
            var vm = new StudentEnhancementViewModel
            {
                Student = db.Table_Student.Find(id),
                Enhancement = null/*db.Table_Cognitive_Enhancement.FirstOrDefault(x => x.StudentID == id)*/,
                Contents = db.Table_CognitiveContent.ToList()
            };
            return View(vm);
        }

        [HttpPost]

        public ActionResult AddCognitiveData(StudentEnhancementViewModel model)
        {
            //var p1 = new Table_Cognitive_Enhancement
            //{
            //    EvaluationPeriod = model.Enhancement.EvaluationPeriod,
            //    EvaluationSt = model.Enhancement.EvaluationSt,
            //    EvaluationYear= model.Enhancement.EvaluationYear,
            //    Kazanım1 = model.
            //}
            model.Enhancement.StudentLastName = model.Student.StudentLastName;
            model.Enhancement.StudentFirstName = model.Student.StudentFirstName;
            model.Enhancement.StudentID = model.Student.StudentID;

            db.Table_Cognitive_Enhancement.Add(model.Enhancement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}