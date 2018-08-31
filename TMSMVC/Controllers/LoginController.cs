using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TMSMVC.ViewModel;

namespace TMSMVC.Controllers
{
    public class LoginController : Controller
    {
        public string check="";

        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        //POST : Login
        [HttpPost]
        public ActionResult Register(Users users)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
            Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

             check = httpClient.PostAsJsonAsync("api/Users/PostUser", users).
                                 Result.Content.ReadAsStringAsync().Result;

            if (check == "\"success\"")
            {
                return RedirectToAction("TaskList", "Task");
            }

            else
            {
                return View("");
            }
        }
        // GET: Signin
        public ActionResult Signin()
        {
            return View("~/Views/Login/Signin.cshtml");
        }

        //POST Signin
        [HttpPost]
        public ActionResult Signin(Users users)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
            Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            check = httpClient.PostAsJsonAsync("api/Users/CheckUser", users).
                                 Result.Content.ReadAsStringAsync().Result;

            if (check == "\"Valid\"")
                return RedirectToAction("TaskList", "Task");
            else
                return View();
        }
        }
    }