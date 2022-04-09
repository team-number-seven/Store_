using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.UserCommands.AddItemToBagItems
{
    public class AddItemToBagItemsHandler:IRequestHandler<AddItemToBagItemCommand,ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly UserManager<User> _userManager;

        public AddItemToBagItemsHandler(IStoreDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ResponseBase> Handle(AddItemToBagItemCommand request, CancellationToken cancellationToken)
        {
            var bagItemDto = request.BagItem;
            var user = await _userManager.FindByIdAsync(bagItemDto.UserId);
            var isAlreadyExistItem = user.BagItems.FirstOrDefault(x => x.ItemId == bagItemDto.ItemId && x.Size.Value == bagItemDto.Size);

            if (isAlreadyExistItem is not null)
                return new AddItemToBagItemResponse(isAlreadyExistItem.Id);

            var item = await _context.Items.FindAsync(bagItemDto.ItemId);
            var itemCountSizes = item.Characteristic.ItemCountSizes.FirstOrDefault(x => x.Size.Value == bagItemDto.Size);
            var size = itemCountSizes!.Size;
            var amount = itemCountSizes!.Count;
            var bagItem = new BagItem {Id = Guid.NewGuid(), Item = item, Size = size, User = user,Amount = amount};

            await _context.BagItems.AddAsync(bagItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddItemToBagItemResponse(bagItem.Id);
        }
    }
}
