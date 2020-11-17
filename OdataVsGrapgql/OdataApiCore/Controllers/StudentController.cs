using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData.Routing;
using OdataApiCore.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;

namespace OdataApiCore.Contollers
{
    //[ApiController]
    //[Route("[controller]")]
    //[ODataRoutePrefix("Students")]
    public class StudentsController : ODataController

    {
        private readonly DAL _dal;

        static List<Student> _students = new List<Student> {
            new Student{ Email="email1@email.com", FirstName="First1", LastName="Last1",Id="1"},
            new Student{ Email="email2@email.com", FirstName="First2", LastName="Last2",Id="2"},
        };
        public StudentsController(DAL dal)
        {
            _dal = dal;
        }
        [EnableQuery()]
        [HttpGet]
        // public IEnumerable<Student> Get()
        public IQueryable<Student> Get()
        {
            //return _students.AsQueryable() ;
            return _dal.Students;
        }
        //[EnableQuery]
        //[ODataRoute]
        //public IHttpActionResult Get()
        //{
        //    return Ok(_students);
        //}

        //[ODataRoute("({id})")]
        //[EnableQuery]
        //public IHttpActionResult GetEntity(string id)
        //{
        //    return Ok(SingleResult.Create<Student>(_students.Where(s => s.Id == id).AsQueryable()));
        //}
    }

}