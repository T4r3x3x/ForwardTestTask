﻿using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using ForwardTestTask.ViewModels;

using ReactiveUI;

namespace ForwardTestTask.Views;

public partial class MainWindow : ReactiveWindow<ViewModelBase>
{
    public MainWindow()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}
