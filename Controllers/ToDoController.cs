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
           List<ToDoModel> toDo = _toDoRepository.SearchAll();

            return View(toDo);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ToDoModel toDo = _toDoRepository.ListForId(id);
            return View(toDo);
        }
        public IActionResult Delete(int id)
        {
            ToDoModel toDo = _toDoRepository.ListForId(id);
            return View(toDo);
        }

        public IActionResult Delete0(int id)
        {
            try
            {
                bool deleted = _toDoRepository.Delete0(id);
                 if (deleted)
                 {
                    TempData["SucessMessage"] = "Successfully deleted!";
                 }
                 else
                 {
                    TempData["ErrorMessage"] = "Could not delete ToDo!";
                }
                 return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["ErrorMessage"] = $"Could not create ToDo, error:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(ToDoModel toDo)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _toDoRepository.Add(toDo);
                    TempData["SucessMessage"] = "Successfully created!";
                    return RedirectToAction("Index");
                }

                return View(toDo);
            }
            catch(System.Exception erro)
            {
                TempData["ErrorMessage"] = $"Could not create ToDo, error:{erro.Message}";
                return RedirectToAction("Index");
            }

           
        }
        [HttpPost]
        public IActionResult Edit(ToDoModel toDo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _toDoRepository.Update(toDo);
                    TempData["SucessMessage"] = "Successfully modify!";
                    return RedirectToAction("Index");
                }
                return View(toDo);
            }
            catch (System.Exception erro)
            {
                TempData["ErrorMessage"] = $"Could not modify ToDo, error:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
