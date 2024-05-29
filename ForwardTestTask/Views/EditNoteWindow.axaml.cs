using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Presentation.ViewModels;

using ReactiveUI;

using System;

namespace ForwardTestTask.Presentation.Views
{
    public partial class EditNoteWindow : ReactiveWindow<EditNoteViewModel>
    {
        private EditNoteViewModel? _viewModel;

        public EditNoteWindow()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }

        ~EditNoteWindow()
        {
            if (_viewModel is not null)
                _viewModel.DialogEnded -= GetEditResult;
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            _viewModel = DataContext as EditNoteViewModel;
            if (_viewModel == null)
                throw new ArgumentException($"Wrong view model type <{_viewModel!.GetType()}>, expect type <{nameof(AddNoteViewModel)}>");
            _viewModel.DialogEnded += GetEditResult;
        }

        private void GetEditResult(NoteDto? addNoteModel) => Close(addNoteModel);
    }
}
