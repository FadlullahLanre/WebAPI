using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDataAccess;

namespace WebAPI.Controllers
{
    public class ExamDetailController : ApiController
    {
        public ExamDetailController()
        {
        }
        //To post examdetails of student
        [HttpPost]
        [Route("api/ExamDetails")]
        public IHttpActionResult PostNewStudent(ExamDetail examDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new db_a06c09_studentdbEntities())
            {
                ctx.ExamDetails.Add(new ExamDetail()
                {
                    Examvenue = examDetail.Examvenue,
                    SubjectOne = examDetail.SubjectOne,
                    SubjectTwo = examDetail.SubjectTwo,
                    SubjectThree = examDetail.SubjectThree,
                    SubjectFour = examDetail.SubjectFour,
                    DateCreated = examDetail.DateCreated,
                    StudentID = examDetail.StudentID
                    
                });

                ctx.SaveChanges();
            }

            return Ok();
        }
        //Returns List of Students Exam Details
        [HttpGet]
        [Route("api/ExamDetails")]
        public IEnumerable<ExamDetail> Get()
        {
            using (db_a06c09_studentdbEntities entities = new db_a06c09_studentdbEntities())
            {
                return entities.ExamDetails.ToList();
            }
        }

        //Returns  Students Exam Detail By StudentId
        [HttpGet]
        [Route("api/ExamDetails/{studentId}")]
        public ExamDetail Get(string id)
        {
            using (db_a06c09_studentdbEntities entities = new db_a06c09_studentdbEntities())
            {
                return entities.ExamDetails.FirstOrDefault(x => x.StudentID == id);
            }
        }
        ///Updates Students Exam Detail
        [HttpPut]
        [Route("api/ExamDetails/{studentId}")]
        public IHttpActionResult Put(ExamDetail examDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new db_a06c09_studentdbEntities())
            {
                var existingDetail = ctx.ExamDetails.Where(s => s.StudentID == examDetail.StudentID)
                                                        .FirstOrDefault<ExamDetail>();

                if (existingDetail != null)
                {
                    existingDetail.SubjectOne = examDetail.SubjectOne;
                    existingDetail.SubjectTwo = examDetail.SubjectTwo;
                    existingDetail.SubjectThree = examDetail.SubjectThree;
                    existingDetail.SubjectFour = examDetail.SubjectFour;
                    existingDetail.Examvenue = examDetail.Examvenue;
                    existingDetail.DateCreated = examDetail.DateCreated;

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
    


        
    
