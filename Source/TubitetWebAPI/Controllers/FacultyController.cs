using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TubitetClasses.Models;
using Newtonsoft.Json;
    
namespace TubitetWebAPI.Controllers
{
    public class FacultyController : ApiController
    {

        [HttpPost]
        public int SaveNewFaculty(Faculty faculty)
        {
            //Faculty faculty = new Faculty();
            //faculty.FacultyName = "Edebiyat";

            return faculty.Save();
        }
        public String getAllFaculties()
        {
            return JsonConvert.SerializeObject(new Faculty().getFaculties(""));
        }
    }
}
