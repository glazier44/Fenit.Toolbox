﻿using System.Windows;

namespace Fenit.Toolbox.WPF.UI.Base
{
    public class BaseDialogView : Window, IDialogView
    {
        public void ShowDialog<T>(T context) where T : IDialogContext
        {
            if (DataContext is IDialogViewModel dialogViewModel)
            {
                context.CloseAction = Close;
                dialogViewModel.DialogContext = context;
            }

            Show();
        }
    }
}