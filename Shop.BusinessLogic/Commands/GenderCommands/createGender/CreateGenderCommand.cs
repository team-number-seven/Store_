using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.GenderCommands.CreateGender
{
    public record CreateGenderCommand(string Title) : IRequest<ResponseBase>;
}