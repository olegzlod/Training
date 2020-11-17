using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using OdataApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OdataApi.Contollers
{
    [ODataRoutePrefix("Students")]
    public class OdataController : ODataController//ApiController
    {
        static List<Student> _students = new List<Student> {
            new Student{ Email="email1@email.com", FirstName="First1", LastName="Last1",Id="1"},
            new Student{ Email="email2@email.com", FirstName="First2", LastName="Last2",Id="2"},
        };

        [EnableQuery]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            return Ok(_students);
        }

        [ODataRoute("({id})")]
        [EnableQuery]
        public IHttpActionResult GetEntity(string id)
        {
            return Ok(SingleResult.Create<Student>(_students.Where(s => s.Id == id).AsQueryable()));
        }
    }
}