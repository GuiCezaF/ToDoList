namespace ToDoList.Application.DTOS
{
    public class ToDoDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Finished { get; private set; } = false;
    }
}