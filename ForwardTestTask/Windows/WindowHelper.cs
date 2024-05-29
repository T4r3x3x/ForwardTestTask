using Avalonia.Controls;

using ForwardTestTask.Presentation.MVVM.ViewModels.Abstraction;

using System.Threading.Tasks;

namespace ForwardTestTask.Presentation.Windows
{
    internal static class WindowHelper
    {
        internal static async Task<TResult?> ShowDialogWindow<TResult, TViewModel, TWindow>(TViewModel dialogViewModel, Window owner)
    where TViewModel : class, IDialogViewModel<TResult>
    where TWindow : DialogWindowBase<TViewModel, TResult>, new()
        {
            var window = new TWindow() { DataContext = dialogViewModel };
            return await window.ShowDialog<TResult?>(owner!);
        }
    }
}
