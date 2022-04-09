using System;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class CreateNumberOfSizeDto
    {
        public Guid SizeId { get; set; }

        public uint Count { get; set; }
    }
}