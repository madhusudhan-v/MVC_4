using System;
using System.Web.Mvc;
using MVC_4.Models;
using MVC_4.Services;

namespace MVC_4.Controllers
{
    public class StudentController : AsyncController
    {
        private readonly IStudentService _studentService;// = new StudentService();
        //public StudentController()//:this(new StudentService())
        //{

        //}

        public StudentController(IStudentService studentServiceIoc)
        {
            _studentService = studentServiceIoc;
        }

        public ActionResult Index()
        {
            return View(_studentService.GetAllStudents());
        }

        public ActionResult Details(int id = 0)
        {
            try
            {
                return View(_studentService.GetStudent(id));
            }
            catch (Exception)
            {
                //return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //StudentController()
        //public void Create()
        public ActionResult  Create()
        {
            return View();   //goes to  http://localhost:6719/Student/Create works as-ususal
            // return View(new WebFormView(this.ControllerContext, "~/Views/test.aspx?"));//to render this inherit test.aspx.cs from System.Web.Mvc.ViewPage instead of System.web.UiPage
            //Response.Redirect("/Subject/Index");  //goes to http://localhost:6719/Subject/Index and shows same page
            //Response.Redirect("google.com"); //goes to http://localhost:6719/Student/google.com
            //Server.TransferRequest("/Subject/Index", false); //goes to subject/index page but shows earlier link itself http://localhost:6719/Student/Create
            //Server.TransferRequest("google.com", false); //goes to /Student/google.com but stays in the same page /student/create
            //Redirect("https://www.google.co.in/");  stays in same link but DONO
            //return RedirectToRoute("googly"); //need to be mentioned the route name in global.asax
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
           
           if (!ModelState.IsValid) return View(student);
            _studentService.AddStudent(student);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int id = 0)
        {
           var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    //st.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}