using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDataAccess;

namespace WebAPI.Controllers
{



    public class StudentController : ApiController
    {
        public StudentController()
        {
        }
        //To Create a new Student Profile
        [HttpPost]
        [Route("api/Student")]
        public IHttpActionResult PostNewStudent(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new db_a06c09_studentdbEntities())
            {
                ctx.Students.Add(new Student()
                {
                    StudentID = student.StudentID,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Department = student.Department
                });

                ctx.SaveChanges();
            }

            return Ok();
        }
        //Returns List of Students
        [HttpGet]
        [Route("api/Student")]
        public HttpResponseMessage Get()
        {
            db_a06c09_studentdbEntities entities = new db_a06c09_studentdbEntities();
                 IEnumerable<Student>  Students = entities.Students.ToList();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Students);
            return response;

        }

        //Login Details
        [HttpGet]
        [Route("api/Student/{studentId}/{FirstName}")]
        public Student Get(Guid id, string FirstName)
        {
            using (db_a06c09_studentdbEntities entities = new db_a06c09_studentdbEntities())
            {
                return entities.Students.Where(x => x.StudentID == id & x.FirstName == FirstName).SingleOrDefault();
            }
        }

        [HttpGet]
        [Route("api/Student/{studentId}")]
        public Student GetStudentByID(Guid id)
        {
            using (db_a06c09_studentdbEntities entities = new db_a06c09_studentdbEntities())
            {
                return entities.Students.Where(x => x.StudentID == id).SingleOrDefault();
            }
        }


        //To update a student profile
        [HttpPut]
        [Route("api/Student")]
        public IHttpActionResult Put(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new db_a06c09_studentdbEntities())
            {
                var existingStudent = ctx.Students.Where(s => s.StudentID == student.StudentID)
                                                        .FirstOrDefault<Student>();

                if (existingStudent != null)
                {
                    existingStudent.FirstName = student.FirstName;
                    existingStudent.LastName = student.LastName;
                    existingStudent.Department = student.Department;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }
    }
}
      



        

    






