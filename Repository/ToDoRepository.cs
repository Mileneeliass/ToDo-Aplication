using ToDo_Aplication.Data;
using ToDo_Aplication.Models;

namespace ToDo_Aplication.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly BancoContext _bancoContext;
        public ToDoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ToDoModel ListForId(int id)
        {
            return _bancoContext.ToDo.FirstOrDefault(x => x.Id == id);
        }
        public List<ToDoModel> SearchAll()
        {
            return _bancoContext.ToDo.ToList();
        }

        public ToDoModel Add(ToDoModel toDo)
        {
            _bancoContext.ToDo.Add(toDo);
            _bancoContext.SaveChanges();
            return toDo;
        }

        public ToDoModel Update(ToDoModel ToDo)
        {
            ToDoModel toDoDB = ListForId(ToDo.Id);
            if (toDoDB == null) throw new Exception("List update error!");
            {
                toDoDB.Name = ToDo.Name;
                toDoDB.Description = ToDo.Description;  
                toDoDB.DateStart = ToDo.DateStart;
                toDoDB.EndDate = ToDo.EndDate;

                _bancoContext.ToDo.Update(toDoDB);
                _bancoContext.SaveChanges();
                return toDoDB;
            }
        }

        public bool Delete0(int id)
        {
            ToDoModel toDoDB = ListForId(id);
            if (toDoDB == null) throw new Exception("List delete error!");

            _bancoContext.ToDo.Remove(toDoDB);
            _bancoContext.SaveChanges();
            return true;    

        }
    }
}
