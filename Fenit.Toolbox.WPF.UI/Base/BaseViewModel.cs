using System;
using System.Windows;
using Fenit.Toolbox.Logger;
using Prism.Mvvm;


namespace Fenit.Toolbox.WPF.UI.Base
{
    public abstract class BaseViewModel : BindableBase //, INotifyPropertyChanged
    {
        protected readonly ILoggerService Log;

        protected BaseViewModel(ILoggerService log)
        {
            Log = log;
        }

        //public string Title { get; protected set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //}

        //protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expr)
        //{
        //    if (expr.Body is MemberExpression body)
        //    {
        //        OnPropertyChanged(body.Member.Name);
        //    }
        //}

        protected void MessageError(string message, string name)
        {
            Log.Error($"[{name}] {message}");
            MessageBox.Show(message, "B��d", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        protected void MessageWarning(string message, string name)
        {
            MessageBox.Show(message, name, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        protected void MessageError(Exception e, string name)
        {
            Log.Error(name, e);
            MessageBox.Show(e.Message, "B��d", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}