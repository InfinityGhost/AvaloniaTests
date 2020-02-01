using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;

namespace AvaloniaTest.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public T GetParent<T>() where T : Window
        {
            var matching = from obj in (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).Windows
                where obj.DataContext == this
                select (T)obj;
            return matching.FirstOrDefault();
        }
    }
}
