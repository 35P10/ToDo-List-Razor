using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class ToDo {
    public int Id { get; set;}
    [Required(ErrorMessage = "Se requiere una descripción")]
    [StringLength(100, MinimumLength = 3,
    ErrorMessage = "{0} debe tener como minimo 1 caracter")]
    public string? Descripcion { get; set;}
    public bool Status { get; set;}
    public DateTime ReleaseDate { get; set; }
}