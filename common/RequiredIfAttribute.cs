using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeSec.common
{
  public class RequiredIfAttribute : ValidationAttribute
  {
    string cert;
    public RequiredIfAttribute(string cert)
    {
      this.cert = cert;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var containerType = validationContext.ObjectInstance.GetType();
      var field = containerType.GetProperty(cert);


      if (field != null)
      {
        // get the value of the dependent property
        var cert = field.GetValue(validationContext.ObjectInstance, null);
        // trim spaces of dependent value

        string certificateValue = cert.ToString();

        if (certificateValue != "true")
        {
          return new ValidationResult("Du måste ange datum för läkarintyget");
        }
      }
        return ValidationResult.Success;
      
    }
  }
}