using AspNet_Hibernate_MVC.Models;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace AspNet_Hibernate_MVC.Controllers
{
    public class TasksController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskRepository _taskRepository;

        public TasksController(ILogger<HomeController> logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _taskRepository = taskRepository;
        }

        public IActionResult Tasks()
        {
            var tasks = _taskRepository.GetTasks();
            return View(tasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DeleteTask(Guid id)
        {
            _taskRepository.Delete(id);

            var tasks = _taskRepository.GetTasks();
            return View(tasks);
        }
    }
}
