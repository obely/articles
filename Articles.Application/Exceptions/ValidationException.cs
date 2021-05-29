using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Articles.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationException(IEnumerable<ValidationFailure> validationFailures)
        {
            ValdationErrors = new List<string>();

            foreach (var validationFailure in validationFailures)
            {
                ValdationErrors.Add(validationFailure.ErrorMessage);
            }
        }
    }
}
