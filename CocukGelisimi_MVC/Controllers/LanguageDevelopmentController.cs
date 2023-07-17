using CocukGelisimi_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CocukGelisimi_MVC.Models.ViewModels;
using System.Runtime.Remoting.Messaging;
using System.Data.Entity.Infrastructure;

namespace CocukGelisimi_MVC.Controllers
{
    public class LanguageDevelopmentController : Controller
    {
        // GET: LanguageDevelopment

        Cocuk_Gelisimi_DbEntities1 db = new Cocuk_Gelisimi_DbEntities1();
        public ActionResult Index()
        {
            var values = db.Table_Student.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult AddLanguageData(int? id) 
        {
            // bu alttkai kod eger sayfa bir id değeri alamazsa index e geri dönsün.
           if (!id.HasValue) return RedirectToAction("Index");

            var vm = new LanguangeDevelopmentViewModel
            {
                // Burda View Modeldeki komple bu değişkenlere attık. bu değişkenleri daha önce Viewmodel cs sayfa
                // da uretmişitk
                Student = db.Table_Student.Find(id),
                Language = null,
                Contents = db.Table_LanguageContent.ToList()
            };
            
            return View(vm);
            
        }

        public ActionResult GetLanguageDevelopmentStudentList(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            // Öğrencileri dil gelişimi index sayfasından öğrencileri düzenleme sayfasına geçmeden önceki listeleme
            // sayfasına atma yeri
            var vm = new LanguangeDevelopmentViewModel
            {
                Languagelist = db.Table_Language_Development.ToList(),
                
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddLanguageData(LanguangeDevelopmentViewModel model)
        {
            // Dil Gelişim verileri ekleme
            model.Language.StudentFullName = model.Student.StudentFirstName + " " + model.Student.StudentLastName;
            model.Language.StudentID = model.Student.StudentID;
            db.Table_Language_Development.Add(model.Language);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult GetLanguageDevelopmentData(int id)
        {
            // verileri Öğrnci liste sayfasından update sayfasına taşıdık (id) ye göre;
            var vm = new LanguangeDevelopmentViewModel
            {
                
                Language = db.Table_Language_Development.Find(id),
                Contents = db.Table_LanguageContent.ToList()
            };
            return View(vm);
            

        }

        public ActionResult UpdateLanguageDevelopmentData(LanguangeDevelopmentViewModel model)
        {

            var updateLanguageData = db.Table_Language_Development.Find(model.Language.LanguageDevelopmentID);


            if (updateLanguageData != null)
            {
                //if (!string.IsNullOrEmpty(p1.EvaluationYear.ToString()))

                updateLanguageData.EvaluationYear = model.Language.EvaluationYear;

                //if (!string.IsNullOrEmpty(p1.EvaluationPeriod))

                updateLanguageData.EvaluationPeriod = model.Language.EvaluationPeriod;

                //if (!string.IsNullOrEmpty(p1.EvaluationSt.ToString()))

                updateLanguageData.EvaluationSt = model.Language.EvaluationSt;
                updateLanguageData.Kazanım1 = model.Language.Kazanım1;
                updateLanguageData.Kazanım2 = model.Language.Kazanım2;
                updateLanguageData.Kazanım3 = model.Language.Kazanım3;
                updateLanguageData.Kazanım4 = model.Language.Kazanım4;
                updateLanguageData.Kazanım5 = model.Language.Kazanım5;
                updateLanguageData.Kazanım6 = model.Language.Kazanım6;
                updateLanguageData.Kazanım7 = model.Language.Kazanım7;
                updateLanguageData.Kazanım8 = model.Language.Kazanım8;
                updateLanguageData.Kazanım9 = model.Language.Kazanım9;
                updateLanguageData.Kazanım10 = model.Language.Kazanım10;
                updateLanguageData.Kazanım11 = model.Language.Kazanım11;
                updateLanguageData.Kazanım12 = model.Language.Kazanım12;
                updateLanguageData.MySuggestion = model.Language.MySuggestion;

            }
            db.SaveChanges();
            return RedirectToAction("GetLanguageDevelopmentStudentList");
        }

    }
}