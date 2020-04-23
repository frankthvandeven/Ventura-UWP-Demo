using System;
using System.Threading.Tasks;
using Ventura.PopupDialogs;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public static class Popup
    {

        public static async Task<bool> ConfirmDelete(string caption = null)
        {
            ConfirmDeleteDialog dialog = new ConfirmDeleteDialog();

            if (caption != null)
                dialog.Title = caption;

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
                return true;

            return false;
        }


    }
}
