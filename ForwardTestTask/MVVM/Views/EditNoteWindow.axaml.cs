using Avalonia.Markup.Xaml;

using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Presentation.MVVM.ViewModels.Abstraction;
using ForwardTestTask.Presentation.MVVM.ViewModels.Implementation;

using ReactiveUI;

namespace ForwardTestTask.Presentation.Views
{
    public partial class EditNoteWindow : DialogWindowBase<EditNoteViewModel, NoteDto>
    {
        public EditNoteWindow()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}