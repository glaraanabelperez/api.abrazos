using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEventHandler.Validators
{
    public class IdOrObjectClassAttribute : IValidatableObject
    {
        public int? id { get; set; }
        public object? objectCommand { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (id==0 && objectCommand==null)
            {
                yield return new ValidationResult("Al menos una de las propiedades debe tener un valor.", new[] { nameof(id), nameof(objectCommand) });
            }
        }
    }
}
