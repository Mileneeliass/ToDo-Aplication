using System.ComponentModel.DataAnnotations;

namespace ToDo_Aplication.Models
{
    public class ToDoModel
    {
        public int Id { get;set; }
        
        [Required(ErrorMessage ="Enter a Name")]
        public string Name { get;set; }

        [Required(ErrorMessage = "Enter a Description")]
        public string Description { get;set; }

        [Required]
        public DateTime DateStart { get;set; }

        [Required]
        public DateTime EndDate { get;set; }



    }
}
