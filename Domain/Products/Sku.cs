namespace Domain.Products
{
    // Stock keeping Unit
    public record Sku
    {
        public string Value { get; init; }

        private const int DefaultLength = 15;

        public Sku(string value)
        {
            Value = value;
        }

        public static Sku? Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            if (value.Length != DefaultLength) return null;

            return new Sku(value);
        }
    }
}
