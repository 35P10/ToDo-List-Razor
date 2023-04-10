using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public List<ToDo> ToDos;
    [BindProperty]
    public ToDo newToDo { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ToDos = ToDoService.GetAll();
    }

    public IActionResult OnPostAdd(){
        if(!ModelState.IsValid){
            return Page();
        }
        ToDoService.Add(newToDo);
        return RedirectToAction("Get");
    }

    public IActionResult OnPostSwitchStatus(int id){
        ToDoService.SwitchStatus(id);
        return RedirectToAction("Get");
    }

    public IActionResult OnPostDelete(int id){
        ToDoService.Remove(id);
        return RedirectToAction("Get");
    }
}
