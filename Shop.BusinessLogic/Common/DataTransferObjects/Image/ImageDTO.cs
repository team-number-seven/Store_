﻿namespace Store.BusinessLogic.Common.DataTransferObjects.Image
{
    public class ImageDto
    {
        public string FileName { get; set; }
        public byte[] Bytes { get; set; }
        public long Length { get; set; }
    }
}