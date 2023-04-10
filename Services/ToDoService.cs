using ToDoList.Models;

namespace ToDoList.Services;

public static class ToDoService {
    static List<ToDo> ToDos {get;}

    static int nextId;

    static ToDoService(){
        ToDos = new List<ToDo> {
            new ToDo { Id = 1, 
            Descripcion = "Hola 1", 
            ReleaseDate = DateTime.Parse("1989-2-12")
            },
            new ToDo { Id = 2, 
            Descripcion = "Hola 1", 
            ReleaseDate = DateTime.Parse("1989-2-12")
            }
        };

        nextId = ToDos.Count + 1;
    }

    public static List<ToDo> GetAll() => ToDos;

    public static ToDo? Get(int id) => ToDos.FirstOrDefault(td => td.Id == id);

    public static void Add(ToDo newToDo){
        newToDo.ReleaseDate = DateTime.Now;
        newToDo.Id = nextId;
        newToDo.Status = false;
        ToDos.Add(newToDo);
        
        nextId++;
    }

    public static void SwitchStatus(int id){
        var index = ToDos.FindIndex(td => td.Id == id);
        ToDos[index].Status = !ToDos[index].Status; 
        return;
    } 

    public static void Remove(int id){
        var todo = Get(id);

        if(todo is not null){
            ToDos.Remove(todo);
        }
        return;
    } 

}