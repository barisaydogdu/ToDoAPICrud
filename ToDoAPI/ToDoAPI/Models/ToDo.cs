namespace ToDoAPI.Models
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Member { get; set; }
        public string Task { get; set; }
        public string Priority { get; set; }
        public bool isDone { get; set; }
        public string UserImagePath { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
