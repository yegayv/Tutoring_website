using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tutoring_Website.Model;

namespace Tutoring_Website.Pages.Tutors
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Tutor Tutor { get; set; }

        public async Task OnGet(int id)
        {
            Tutor = await _db.Tutors.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Tutors.FindAsync(Tutor.tutor_id);
                BookFromDb.tutor_name = Tutor.tutor_name;
                BookFromDb.tutor_description = Tutor.tutor_description;
                BookFromDb.tutor_subjects = Tutor.tutor_subjects;
                BookFromDb.tutor_rate = Tutor.tutor_rate;
                BookFromDb.tutor_img = Tutor.tutor_img;
                BookFromDb.tutor_rating = Tutor.tutor_rating;
                BookFromDb.tutor_date_joined = Tutor.tutor_date_joined;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
