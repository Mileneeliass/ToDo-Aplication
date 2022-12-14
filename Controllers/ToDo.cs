using Microsoft.AspNetCore.Mvc;
using ToDo_Aplication.Models;
using ToDo_Aplication.Repository;

namespace ToDo_Aplication.Controllers
{

    public class ToDoController : Controller
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDoModel toDo)
        {
            _toDoRepository.Add(toDo);
            return RedirectToAction("Index");
        }

    }
}
