﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces
{
    public interface IActionPane : IViewBase
    {
        bool IsDisposed { get; }
    }
}
