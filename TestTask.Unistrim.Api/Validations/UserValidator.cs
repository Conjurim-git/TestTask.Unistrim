using FluentValidation;
using TestTask.Unistrim.Api.Dto;

namespace TestTask.Unistrim.Api.Validations;

    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id пользователя обязателен");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Имя пользователя обязательно");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Фамилия пользователя обязательна");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Необходимо добавить почтовый адрес");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Придумайте пароль");
        }
    }

