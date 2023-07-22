using ToDoList.Domain.Validations;

namespace ToDoList.Domain.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; } = false;

        public ToDo(string name, string description)
        {
            Validation(name, description);
        }

        public ToDo(int id, string name, string description)
        {
            DomainValidationException.When(id < 0, "id deve ser maior que 0");
            Id = id;
            Validation(name, description);
        }

        private void Validation(string name, string description)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name),
                "O nome da tarefa deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(description),
                "A Descrição deve ser informada");

            Name = name;
            Description = description;
        }
    }
}