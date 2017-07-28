﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Controllers.Validators
{
    public class EmptyValidator<T> : AbstractValidator<T>
    {
        // used when no other validator is found
    }
}
