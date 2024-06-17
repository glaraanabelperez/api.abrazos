using ServiceEventHandler.Command.CreateCommand;
using ServiceEventHandler.Command.UpdateCommand;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Validators
{
    public class ValidateDateTimeRangeAtributte : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateRanges = value as List<RangedateCreate>;
            if (dateRanges == null)
            {
                return new ValidationResult("El campo DateTimes es obligatorio.");
            }

            foreach (var dateRange in dateRanges)
            {
                if (dateRange.dateInit == null || dateRange.dateFinish == null || dateRange.dateInit >= dateRange.dateFinish || dateRange.dateInit < DateTime.Now)
                {
                    return new ValidationResult($"La fecha de inicio ({dateRange.dateInit}) no puede ser ni nulas ni mayor que la fecha de fin ({dateRange.dateFinish}).");
                }
   
            }

            return ValidationResult.Success;
        }
    }

    public class ValidateDateTimeAtributte : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = value as RangedateUpdate;

            if (date.dateInit == null || date.dateFinish == null || date.dateInit >= date.dateFinish || date.dateInit < DateTime.Now)
            {
                return new ValidationResult($"La fecha de inicio ({date.dateInit}) no puede ser mayor que la fecha de fin ({date.dateFinish}).");
            }


            return ValidationResult.Success;
        }
    }

}
