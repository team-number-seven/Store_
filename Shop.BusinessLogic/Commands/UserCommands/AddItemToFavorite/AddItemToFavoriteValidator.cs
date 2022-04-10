using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.UserCommands.AddItemToFavorite
{
    public class AddItemToFavoriteValidator : IValidationHandler<AddItemToFavoriteCommand>
    {
        private readonly IStoreDbContext _context;
        private readonly UserManager<User> _userManager;

        public AddItemToFavoriteValidator(IStoreDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ValidationResult> Validate(AddItemToFavoriteCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.FavoriteItem.UserId);
            if (user.FavoriteItems.FirstOrDefault(x => x.Item.Id == request.FavoriteItem.ItemId) is not null)
                return ValidationResult.Fail("Favorite element has already been added");


                return await _context.Items.FindAsync(request.FavoriteItem.ItemId) is null
                ? ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(request.FavoriteItem.ItemId)))
                : ValidationResult.Success;
        }
    }
}