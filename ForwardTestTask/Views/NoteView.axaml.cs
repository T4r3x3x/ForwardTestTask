using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using ForwardTestTask.ViewModels;

using ReactiveUI;

namespace ForwardTestTask.Views;

public partial class MainView : ReactiveUserControl<NoteViewModel>
{
    public MainView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}
