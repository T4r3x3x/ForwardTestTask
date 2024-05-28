using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using ForwardTestTask.ViewModels;

using ReactiveUI;

namespace ForwardTestTask.Views;

public partial class NoteView : ReactiveUserControl<NoteViewModel>
{
    public NoteView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}
