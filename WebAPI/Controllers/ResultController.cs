using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDataAccess;

namespace WebAPI.Controllers
{
    public class ResultController : ApiController
    {
        //Returns List of student Results
        [HttpGet]
        [Route("api/Results")]
        public IEnumerable<Result> Get()
        {
            using (db_a06c09_studentdbEntities entities = new db_a06c09_studentdbEntities())
            {
                return entities.Results.ToList();
            }
        }

        //Returns  Student's Result By StudentId
        [HttpGet]
        [Route("api/Results/{studentId}")]
        public Result Get(string id)
        {
            using (db_a06c09_studentdbEntities entities = new db_a06c09_studentdbEntities())
            {
                return entities.Results.FirstOrDefault(x => x.StudentID == id);
            }
        }
    }
}
