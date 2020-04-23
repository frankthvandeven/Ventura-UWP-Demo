using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public partial class SmartPage : ContentControl
    {
        public Validator<T> CreateValidator<T>(T viewmodel) where T : INotifyPropertyChanged
        {
            return new Validator<T>(this, viewmodel);
        }

    }
}
