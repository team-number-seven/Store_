using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.GenderCommands.CreateGender
{
    public record CommandCreateGender(string Title) : IRequest<ResponseBase>;
}