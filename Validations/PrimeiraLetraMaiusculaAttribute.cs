using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Validations
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Bypass/Contorno da validação do atributo Required - Passa para a segunda validação
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var primeiraLetra = value.ToString()?[0].ToString();
            if (primeiraLetra != primeiraLetra?.ToUpper())
            {
                return new ValidationResult("A primeira letra do nome do produto deve ser maiúscula!");
            }
            return ValidationResult.Success;
        }
    }
}