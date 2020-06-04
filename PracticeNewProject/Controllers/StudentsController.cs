using PracticeNewProject.Data;
using PracticeNewProject.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PracticeNewProject.Controllers
{
    public class StudentsController : Controller
    {
        private NewProjectContext db = new NewProjectContext();

        public ActionResult Index()
        {
            var students = db.Students
                .Include(s => s.Course)
                .Include(s => s.Skills)
                .Include(s => s.Hobbies);

            return View(students.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Student student = db.Students.Find(id);

            if (student == null)
                return HttpNotFound();

            return View(student);
        }


        public ActionResult Create()
        {
            ViewBag.AvailableHobbies = db.Hobbies.ToList();
            ViewBag.AvailableCourses = db.Courses.ToList();
            ViewBag.AvailableSkills = db.Skills.ToList();

            var student = new Student();
            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            {
                if (ModelState.IsValid)
                {
                    //convert the selected ids into objects
                    student.Course = db.Courses.Find(student.CourseId.Value);

                    if (student.SelectedHobbyIds != null)
                    {
                        foreach (var id in student.SelectedHobbyIds)
                            student.Hobbies.Add(db.Hobbies.Find(id));
                    }

                    if (student.SelectedSkillIds != null)
                    {
                        foreach (var id in student.SelectedSkillIds)
                            student.Skills.Add(db.Skills.Find(id));
                    }
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AvailableCourse = db.Courses.ToList();
                ViewBag.AvailableHobbies = db.Hobbies.ToList();
                ViewBag.AvailableSkills = db.Skills.ToList();

                return View(student);
            }
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Student student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();

            student.SelectedHobbyIds = student.Hobbies.Select(m => m.Id).ToList();
            student.SelectedSkillIds = student.Skills.Select(m => m.Id).ToList();

            ViewBag.AvailableCourses = db.Courses.ToList();
            ViewBag.AvailableHobbies = db.Hobbies.ToList();
            ViewBag.AvailableSkills = db.Skills.ToList();

            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student studentParameter)
        {
            var student = db.Students.Find(studentParameter.StudentId);
            if (student == null)
                return new HttpNotFoundResult();

            if (ModelState.IsValid)
            {
                student.Address = studentParameter.Address;
                student.GenderMale = studentParameter.GenderMale;
                student.Password = studentParameter.Password;
                student.UserName = studentParameter.UserName;
                student.Course = db.Courses.Find(studentParameter.CourseId.Value);

                if (studentParameter.SelectedHobbyIds == null)
                    student.Hobbies.ToList().ForEach(m => student.Hobbies.Remove(m));
                else
                {
                    // First remove items that are no longer selected
                    student.Hobbies.Where(m => !studentParameter.SelectedHobbyIds.Contains(m.Id))
                        .ToList().ForEach(m => student.Hobbies.Remove(m));

                    // Now add newly selected hobbies
                    var existingHobbyIds = student.Hobbies.Select(m => m.Id).ToList();
                    var newHobbyIds = studentParameter.SelectedHobbyIds.Except(existingHobbyIds).ToList();
                    db.Hobbies.Where(m => newHobbyIds.Contains(m.Id))
                        .ToList().ForEach(m => student.Hobbies.Add(m));
                }

                if (studentParameter.SelectedSkillIds == null)
                    student.Skills.ToList().ForEach(m => student.Skills.Remove(m));
                else
                {
                    // First remove items that are no longer selected
                    student.Skills.Where(m => !studentParameter.SelectedSkillIds.Contains(m.Id))
                        .ToList().ForEach(m => student.Skills.Remove(m));

                    // Now add newly selected skills
                    var existingSkillsIds = student.Skills.Select(m => m.Id);
                    var newSkillsIds = studentParameter.SelectedSkillIds.Except(existingSkillsIds);
                    db.Skills.Where(m => newSkillsIds.Contains(m.Id))
                        .ToList().ForEach(m => student.Skills.Add(m));
                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            student.SelectedHobbyIds = student.Hobbies.Select(m => m.Id).ToList();
            student.SelectedSkillIds = student.Skills.Select(m => m.Id).ToList();

            ViewBag.AvailableCourses = db.Courses.ToList();
            ViewBag.AvailableHobbies = db.Hobbies.ToList();
            ViewBag.AvailableSkills = db.Skills.ToList();

            return View(student);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Student student = db.Students.Find(id);

            if (student == null)
                return HttpNotFound();

            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
