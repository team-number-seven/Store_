﻿using System;

namespace Store.BusinessLogic.Common.DataTransferObjects.BagItem
{
    public class AddBagItemDto
    {
        public string UserId { get; set; }//optional parameter
        public Guid ItemId { get; set; }
        public string Size { get; set; }
    }
}
