﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTestProject.Desktop.ViewModels.BaseVM;

namespace WorkTestProject.Desktop.Interfaces
{
    interface IChangeableContent
    {
        public event Action<BaseViewModel, string> ChangeContent;
    }
}
