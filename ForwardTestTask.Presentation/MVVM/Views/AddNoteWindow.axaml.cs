using Avalonia.Markup.Xaml;

using ForwardTestTask.Presentation.Models;
using ForwardTestTask.Presentation.MVVM.ViewModels.Abstraction;
using ForwardTestTask.Presentation.MVVM.ViewModels.Implementation;

using ReactiveUI;

namespace ForwardTestTask.Presentation.Views
{
    public partial class AddNoteWindow : DialogWindowBase<AddNoteViewModel, AddNoteModel>
    {
        public AddNoteWindow()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
