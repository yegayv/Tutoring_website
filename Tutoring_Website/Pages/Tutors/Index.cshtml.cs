using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tutoring_Website.Model;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tutoring_Website.Pages.Tutors
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(ApplicationDbContext db, IHttpClientFactory clientFactory, ILogger<IndexModel> logger)
        {
            _db = db;
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public IEnumerable<Tutor> Tutors { get; set; }
        public IEnumerable<Tutor> TutorList { get; set; }


        public Product json { get; set; }

        public async Task OnGet()
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://projectrainforest.azurewebsites.net/api/VendorProduct/GetVendorProducts/25");

            var client = _clientFactory.CreateClient();
           

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {

                _logger.LogInformation("Test response:");
               var readContent = await response.Content.ReadAsStringAsync();
               
                var ProductInfo = JArray.Parse(readContent)["productInfo"];
                var productString = JsonConvert.DeserializeObject(ProductInfo.ToString());

            
                //var ProductList = (JObject)JsonConvert.DeserializeObject(readContent);





                /*    foreach(var product in ProductList)
                     {
                         Tutor tutor = new Tutor();
                         tutor.tutor_id = product.product_id;
                         tutor.tutor_name = product.product_name;
                         tutor.tutor_description = product.product_info.product_description;
                         tutor.tutor_subjects = product.product_info.product_description;
                         tutor.tutor_rate = product.product_info.product_price;
                         tutor.tutor_img = product.product_info.product_img;
                         tutor.tutor_rating = product.product_info.product_rating;
                         tutor.tutor_date_joined = product.product_info.product_date;
                         TutorList.Append(tutor);
                     }

     */
            }

            

            Tutors = await _db.Tutors.ToListAsync();
            
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var tutor = await _db.Tutors.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            _db.Tutors.Remove(tutor);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
