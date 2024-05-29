using Avalonia.Controls;

using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

using System.Threading.Tasks;

namespace ForwardTestTask.Presentation.MessageBoxes
{
    internal static class MessageBoxHelper
    {
        internal static async Task ShowErrorMessageBoxAsync(string message)
        {
            var messageBox = MessageBoxManager.GetMessageBoxStandard("Error", message, ButtonEnum.Ok);
            await messageBox.ShowAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Возвращает результат действий пользователя, true - согласен, false - нет</returns>
        internal static async Task<bool> ShowConfirmMessageBoxAsync(Window window, string message)
        {
            var messageBox = MessageBoxManager.GetMessageBoxStandard("Confirm", message, ButtonEnum.YesNo);
            var result = await messageBox.ShowWindowDialogAsync(window);
            if (result == ButtonResult.Yes)
                return true;
            return false;
        }
    }
}