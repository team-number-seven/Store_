namespace Store.BusinessLogic.Validation
{
    public record ValidationResult
    {
        public bool IsSuccessful { get; set; } = true;
        public string Error { get; init; }
        public static ValidationResult Success => new();

        public static ValidationResult Fail(string error)
        {
            return new ValidationResult {IsSuccessful = false, Error = error};
        }
    }
}