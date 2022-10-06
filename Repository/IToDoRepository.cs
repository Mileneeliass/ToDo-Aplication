using ToDo_Aplication.Models;

namespace ToDo_Aplication.Repository
{
    public interface IToDoRepository
    {
        ToDoModel ListForId(int id);
        List<ToDoModel> SearchAll();
        ToDoModel Add(ToDoModel ToDo);
        ToDoModel Update(ToDoModel ToDo);

        bool Delete0(int id);

    }
}
