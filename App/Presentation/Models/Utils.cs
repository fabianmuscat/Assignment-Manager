using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Presentation.Models
{
    public class Utils
    {
        public static object ValidateForm(List<FormControl> list)
        {
            object ret = new { valid = true };
            foreach (var formControl in list)
            {
                var validator = formControl.Validator;
                if (validator == Validators.Required)
                {
                    if (formControl.Value is IFormFile[] files)
                    {
                        if (files.Length != 0) continue;
                        ret = new { valid = false, error = formControl.Error };
                        break;
                    }

                    if (!string.IsNullOrEmpty(formControl.Value as string)) continue;
                    ret = new { valid = false, error = formControl!.Error };
                    break; // if we arrived here, it means the form control is invalid so break the loop and return the error
                }

                if (validator != Validators.PasswordLength) continue;
                if (formControl.Value != null &&
                    formControl.Value.ToString()!.Length < (int)Validators.PasswordLength)
                    ret = new { valid = false, error = formControl!.Error };
            }

            return ret;
        }
    }   
}

