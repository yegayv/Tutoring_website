using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutoring_Website.Model;

namespace Tutoring_Website.Controllers
{
    [Route("api/tutors")]
    [ApiController]
    public class TutorsController : Controller
    {
       private readonly ApplicationDbContext _db;

        public TutorsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet] 
        public IActionResult GetAllTutors()
        {
            return Json(new { data = _db.Tutors.ToList() });
        }   
    }
}
