using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Gender;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public class GetGenderByIdHandler : IRequestHandler<GetGenderByIdQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetGenderByIdHandler> _logger;
        private readonly IMapper _mapper;

        public GetGenderByIdHandler(IStoreDbContext context, IMapper mapper, ILogger<GetGenderByIdHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetGenderByIdQuery request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.FindAsync(request.Id);
            _logger.LogInformation(LoggerMessages.DoneMessage("Handle"));
            return new GetGenderByIdResponse(_mapper.Map<GenderDto>(gender));
        }
    }
}