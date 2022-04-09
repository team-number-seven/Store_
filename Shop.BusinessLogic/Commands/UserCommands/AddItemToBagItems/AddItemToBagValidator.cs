using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.UserCommands.AddItemToBagItems
{
    public class AddItemToBagValidator : IValidationHandler<AddItemToBagItemCommand>
    {
        private readonly IStoreDbContext _context;
        private readonly UserManager<User> _userManager;

        public AddItemToBagValidator(IStoreDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ValidationResult> Validate(AddItemToBagItemCommand request,
            CancellationToken cancellationToken)
        {
            var bagItem = request.BagItem;
            var user = await _userManager.FindByIdAsync(bagItem.UserId);

            if (user is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(bagItem.UserId)));

            if (await _context.Items.FindAsync(bagItem.ItemId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(bagItem.ItemId)));

            return await _context.Sizes.FirstOrDefaultAsync(s => s.Value == bagItem.Size, cancellationToken) is null
                ? ValidationResult.Fail(LoggerMessages.NotFoundMessage(nameof(bagItem.Size)))
                : ValidationResult.Success;
        }
    }
}