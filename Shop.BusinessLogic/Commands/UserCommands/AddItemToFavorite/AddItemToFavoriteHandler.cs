using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.UserCommands.AddItemToFavorite
{
    public class AddItemToFavoriteHandler:IRequestHandler<AddItemToFavoriteCommand,ResponseBase>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStoreDbContext _context;

        public AddItemToFavoriteHandler(UserManager<User> userManager,IStoreDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<ResponseBase> Handle(AddItemToFavoriteCommand request, CancellationToken cancellationToken)
        {
            var dto = request.FavoriteItem;

            var user = await _userManager.FindByIdAsync(dto.UserId);
            var item = await _context.Items.FindAsync(dto.ItemId);
            var favoriteItem = new FavoriteItem {Id = Guid.NewGuid(), Item = item, User = user};
            await _context.FavoriteItems.AddAsync(favoriteItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddItemToFavoriteResponse(favoriteItem.Id);

        }
    }
}
