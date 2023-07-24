using FluentValidation;

namespace ToDoList.Application.DTOS.Validations
{
    public class ToDoDTOValidator : AbstractValidator<ToDoDTO>
    {
        public ToDoDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Um nome deve ser informado");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Uma descrição deve ser informada");
            RuleFor(x => x.Finished).NotEmpty().NotNull().WithMessage("O Status da tarefa deve ser informado");
        }
    }
}