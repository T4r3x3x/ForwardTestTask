using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ForwardTestTask.Presentation.MVVM.ViewModels.Implementation;
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
