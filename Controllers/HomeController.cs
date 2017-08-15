using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/CategoryForm")]
    public ActionResult CategoryForm()
    {
      return View();
    }

    [HttpGet("/Categories")]
    public ActionResult CategoriesGet()
    {
      return View("Categories",Category.GetAll());
    }

    [HttpPost("/Categories")]
    public ActionResult Categories()
    {
      string categoryName = Request.Form["category"];
      Category newCategory = new Category(categoryName);
      newCategory.Save();

      return View(Category.GetAll());
    }

    [HttpGet("/CategoryDetails/{id}")]
    public ActionResult CategoryDetails(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object> ();

      Category selectedCategory = Category.Find(id);
      List<Task> categoryTaskList = selectedCategory.GetTasks();

      model.Add("category", selectedCategory);
      model.Add("tasks", categoryTaskList);

      return View(model);
    }

  }
}