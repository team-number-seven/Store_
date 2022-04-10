using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.BagItem;
using Store.BusinessLogic.Common.DataTransferObjects.FavoriteItem;
using Store.BusinessLogic.Queries.UserQueries.GetBagItems;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.GetFavoriteItems
{
    public class GetFavoriteItemsHandler:IRequestHandler<GetFavoriteItemsQuery,ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetFavoriteItemsHandler(IStoreDbContext context,UserManager<User> userManager,IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ResponseBase> Handle(GetFavoriteItemsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            var favoriteItems = user.FavoriteItems.ToList();
            var favoriteItemsDto = await MappingFavoriteItemToDtoAsync(favoriteItems, request.Count, cancellationToken);

            return new GetFavoriteItemsResponse(favoriteItemsDto);
        }
        public async Task<IList<GetFavoriteItemDto>> MappingFavoriteItemToDtoAsync(IList<FavoriteItem> bagItems, uint countItem, CancellationToken cancellationToken)
        {
            var favoriteItemDto = new List<GetFavoriteItemDto>();
            await Task.Run(async () =>
            {
                for (var i = 0; i < countItem && i < bagItems.Count; i++)
                {
                    var itemDto = _mapper.Map<GetFavoriteItemDto>(bagItems[i]);
                    var image = bagItems[i].Item.Images.First();
                    itemDto.Image = new FileContentResult(await File.ReadAllBytesAsync(image.Path, cancellationToken), image.ImageFormat.Format);
                    favoriteItemDto.Add(itemDto);
                }
            }, cancellationToken);

            return favoriteItemDto;
        }
    }
}
