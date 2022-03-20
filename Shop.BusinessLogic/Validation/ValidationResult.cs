using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Validation
{
    public record ValidationResult
    {
        public bool IsSuccessful { get; set; } = true;
        public string Error { get; init; }
        public static ValidationResult Success => new ValidationResult();
        public static ValidationResult Fail(string error) => new ValidationResult { IsSuccessful = false, Error = error };
    }
}
