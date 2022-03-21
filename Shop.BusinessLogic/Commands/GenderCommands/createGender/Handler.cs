using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.GenderCommands.createGender
{
    public static partial class CreateGender
    {
        public class Handler : IRequestHandler<Command,Response>
        {
            private readonly IStoreDbContext _context;

            public Handler(IStoreDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                Gender gender = new Gender {Id = Guid.NewGuid(),Title = request.Title};
                await _context.Genders.AddAsync(gender,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return new Response(gender.Id);
            }
        }
    }
}
