using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainValidationExamples.Validations
{
    public interface IOrderValidation
    {
        bool IsValid(object request, out List<string> errors);
    }
}
