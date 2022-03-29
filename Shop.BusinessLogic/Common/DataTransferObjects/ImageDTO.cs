using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class ImageDTO
    {
        public string FileName { get; set; }
        public byte[] Bytes { get; set; }
        public long Length { get; set; }
    }
}
