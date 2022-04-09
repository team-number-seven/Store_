using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.BagItem;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.GetBagItems
{
    public class GetBagItemsHandler:IRequestHandler<GetBagItemsQuery,ResponseBase>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetBagItemsHandler(IStoreDbContext context,UserManager<User> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ResponseBase> Handle(GetBagItemsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            var bagItems = user.BagItems.ToList();
            var bagItemsDto = await MappingBagItemsToDtoAsync(bagItems,request.Count,cancellationToken);

            return new GetBagItemsResponse(bagItemsDto);
        }

        public async Task<IList<GetBagItemDto>> MappingBagItemsToDtoAsync(IList<BagItem> bagItems,uint countItem,CancellationToken cancellationToken)
        {
            var bagItemsDto = new List<GetBagItemDto>();
            await Task.Run(async () =>
            {
                for (var i = 0; i < countItem && i < bagItems.Count; i++)
                {
                    var itemDto = _mapper.Map<GetBagItemDto>(bagItems[i]);
                    var image = bagItems[i].Item.Images.First();
                    itemDto.Image = new FileContentResult(await File.ReadAllBytesAsync(image.Path, cancellationToken), image.ImageFormat.Format);
                    bagItemsDto.Add(itemDto);
                }
            }, cancellationToken);

            return bagItemsDto;
        }
    }
}
