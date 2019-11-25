﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHabit.ViewModel
{
     public class ViewModelBase : INotifyPropertyChanged
     {
          public event PropertyChangedEventHandler PropertyChanged;

          protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
          {
               if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
     }
}
