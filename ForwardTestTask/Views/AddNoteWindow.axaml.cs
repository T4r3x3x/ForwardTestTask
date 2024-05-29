using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using ForwardTestTask.Presentation.Models;
using ForwardTestTask.Presentation.ViewModels;

using ReactiveUI;

using System;

namespace ForwardTestTask.Presentation.Views
{
    public partial class AddNoteWindow : ReactiveWindow<AddNoteViewModel>
    {
        private AddNoteViewModel? _viewModel;

        public AddNoteWindow()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }

        ~AddNoteWindow()
        {
            if (_viewModel is not null)
                _viewModel.DialogEnded -= GetAddingResult;
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            _viewModel = DataContext as AddNoteViewModel;
            if (_viewModel == null)
                throw new ArgumentException($"Wrong view model type <{_viewModel!.GetType()}>, expect type <{nameof(AddNoteViewModel)}>");
            _viewModel.DialogEnded += GetAddingResult;
        }

        private void GetAddingResult(AddNoteModel? addNoteModel) => Close(addNoteModel);
    }
}
