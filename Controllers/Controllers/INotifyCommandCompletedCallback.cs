﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    public interface INotifyCommandCompletedCallback
    {
        event Action Completed;
    }
}
