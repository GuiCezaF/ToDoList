namespace ToDoList.Domain.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
    }
}