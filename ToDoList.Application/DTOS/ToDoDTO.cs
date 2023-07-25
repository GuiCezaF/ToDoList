namespace ToDoList.Application.DTOS
{
    public class ToDoDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public bool Finished { get;  set; }
    }
}