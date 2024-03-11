using ChatMiniService.ViewModels;
using FluentValidation;

namespace ChatMiniService.FluentValidators
{
    public class MessageViewModelValidator : AbstractValidator<MessageViewModel>
    {
        public MessageViewModelValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty();
            
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("There is no name with less then 2 symbols");
        }
    }
}
