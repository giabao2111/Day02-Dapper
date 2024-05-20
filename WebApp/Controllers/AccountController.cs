using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Model;
namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private string url = "http://localhost:5036/api/Account/";
        private HttpClient client = new HttpClient();
        [HttpGet]
        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Account>>(client.GetStringAsync(url).Result);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            try
            {
                var model = client.PostAsJsonAsync(url, account).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fail");

                }
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(string no)
        {
            try
            {
                var model = client.DeleteAsync(url + no).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ViewBag.msg = "Delete fail...!!!";
                }
            }
            catch (Exception ex)
            {

                ViewBag.msg =ex.Message ;
            }

            return View();
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var movie = JsonConvert.DeserializeObject<Account>(content);
                return View(movie);
            }
            else
            {
                ViewBag.msg = "Failed to retrieve genre for editing.";
                return View();
            }
        }
        [HttpPost]
        public IActionResult Edit(Account movie)
        {
            try
            {
                var model = client.PutAsJsonAsync(url, movie).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fail");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }
    }
}
