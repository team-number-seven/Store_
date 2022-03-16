namespace Shop.DAL.Entities
{
    public class Logo:BaseEntity
    {
        public byte[] ImageData { get; set; }
        public string Format { get; set; }

        public Brand Brand { get; set; }
    }
}