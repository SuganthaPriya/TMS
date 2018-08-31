using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TMSMVC.ViewModel;

namespace TMSMVC.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult TaskList()
        {
            IEnumerable<TaskView> tasks = null;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
                Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("api/Tasks/GetTasks").Result;
            if (response.IsSuccessStatusCode)
            {
                tasks = response.Content.ReadAsAsync<IEnumerable<TaskView>>().Result;
            }
            return View(tasks);

        }
        public ActionResult NewTask()
        {
            return View("~/Views/Task/NewTask.cshtml");
            
        }
        [HttpPost]
        public ActionResult NewTask(TaskCreate taskCreate)
        {
            return View();

        }
    }
}