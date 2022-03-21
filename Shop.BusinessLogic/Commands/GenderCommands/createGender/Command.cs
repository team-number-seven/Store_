using MediatR;

namespace Store.BusinessLogic.Commands.GenderCommands.createGender
{
    public static partial class CreateGender
    {
        public record Command(string Title):IRequest<Response>;
    }
}
