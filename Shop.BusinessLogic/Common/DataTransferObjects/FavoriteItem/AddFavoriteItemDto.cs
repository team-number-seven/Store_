using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Common.DataTransferObjects.FavoriteItem
{
    public class AddFavoriteItemDto
    {
        public string UserId { get; set; }//do not pass this parameter
        public Guid ItemId { get; set; }

    }
}
