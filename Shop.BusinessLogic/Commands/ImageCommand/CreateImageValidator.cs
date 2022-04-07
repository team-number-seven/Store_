﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Validation;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ImageCommand
{
    public class CreateImageValidator : IValidationHandler<CreateImageCommand>
    {
        private readonly IStoreDbContext _context;

        public CreateImageValidator(IStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Images;

            if (await _context.Items.FindAsync(dto.ItemId) is null)
                return ValidationResult.Fail(LoggerMessages.NotFoundMessage("Item"));

            // TODO await function
            var task = new Task<ValidationResult>(() =>
            {
                foreach (var file in dto.Files)
                    if (_context.ImageFormats.FirstOrDefault(i => i.Format == file.ContentType) is null)
                        return ValidationResult.Fail($"Invalid format image{file.FileName}");
                return ValidationResult.Success;
            });
            task.Start();
            task.Wait();

            return task.Result;
        }
    }
}