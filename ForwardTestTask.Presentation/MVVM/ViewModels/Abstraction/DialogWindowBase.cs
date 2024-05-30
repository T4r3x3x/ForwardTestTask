using Avalonia.ReactiveUI;

using ForwardTestTask.Presentation.MVVM.ViewModels.Implementation;

using System;

namespace ForwardTestTask.Presentation.MVVM.ViewModels.Abstraction
{
    public abstract class DialogWindowBase<TViewModel, VResultData> : ReactiveWindow<TViewModel> where TViewModel : class, IDialogViewModel<VResultData>
    {
        protected TViewModel? _viewModel;
        protected IDisposable? _disposable;

        ~DialogWindowBase()
        {
            _disposable?.Dispose();
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            _viewModel = DataContext as TViewModel;
            if (_viewModel == null)
                throw new ArgumentException($"Wrong view model type <{_viewModel!.GetType()}>, expect type <{nameof(AddNoteViewModel)}>");

            _disposable = _viewModel.DialogEnded.Subscribe(GetResultData);
        }

        protected void GetResultData(VResultData? data) => Close(data);
    }
}