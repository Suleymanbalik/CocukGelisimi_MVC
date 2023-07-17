using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CocukGelisimi_MVC.Models.Entity;
using System.IO;


namespace CocukGelisimi_MVC.Controllers
{
    public class StudentInfoController : Controller
    {
        // GET: StudentInfo
        Cocuk_Gelisimi_DbEntities1 db = new Cocuk_Gelisimi_DbEntities1();
        public ActionResult Index()
        {
            // ------------ Öğrencileri Listeleme --------------------
            var values = db.Table_Student.ToList();
            return View(values);
        }

        // ------- bu kısım öğrenci ekle butonuna bastıgımızda boş deger girmemesi için yaptık -----------
        [HttpGet]
        public ActionResult AddStudent() 
        { 
            return View();
        }

        // ------------- bu kısım öğrenci ekle kısmı ------------------------
        [HttpPost]
        public ActionResult AddStudent(Table_Student p)
        {
            if (Request.Files.Count>0)
            {
                //  bu kısım fotoğraf ekleme kısmı 
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string pth = "~/StudentPics/" +filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(pth));
                p.StudentPicture= "/StudentPics/" + filename + extension;
            }
            db.Table_Student.Add(p);
            db.SaveChanges();
            // eger return View ("Index") Kullanırsan hata alırsın. Hata: Model.get null hatası gelir.
            return RedirectToAction("Index");
        }

        // --------------- Öğrncileri silme ---------------------------------
        public ActionResult DeleteStudent(int id)
        {
            var student = db.Table_Student.Find(id);
            db.Table_Student.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // ------------------- Öğrecileri StudentId ye göre Guncelleme SAyfasına Aktarma --------------

        public ActionResult GetStudentInfo(int id)
        {
            var getstdnt = db.Table_Student.Find(id);
            return View("GetStudentInfo", getstdnt);

        }
        // ------------------Guncelleme Sayfasında Öğrenci Guncelleme --------------------------
        public ActionResult UpdateStudent(Table_Student p2)
        {
            if (Request.Files.Count > 0)
            {
                // bu kısım fotoğraf ekleme kısmı
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string pth = "~/StudentPics/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(pth));
                p2.StudentPicture = "/StudentPics/" + filename + extension;
            }
            var updateStudent = db.Table_Student.Find(p2.StudentID);
            updateStudent.StudentID = p2.StudentID;
            updateStudent.StudentFirstName = p2.StudentFirstName;
            updateStudent.StudentLastName = p2.StudentLastName;
            updateStudent.StudentYearAsMonth = p2.StudentYearAsMonth;
            if(!string.IsNullOrEmpty(p2.StudentPicture))
                updateStudent.StudentPicture = p2.StudentPicture;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // ------------- Öğrenci listesini çıktı şeklinde alma ----------------------

        public ActionResult StudentlistOutput()
        {
            var values = db.Table_Student.ToList();
            return View(values);
        }
    }
}