using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Ventura.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Ventura.Controls
{

    public class Validator<T> : ValidatorBase where T : INotifyPropertyChanged
    {
        public delegate void ValidateEventDelegate(Validator<T> sender, T viewmodel, ValidateEventArgs<T> e);
        public event ValidateEventDelegate ValidateEvent;

        private T _viewmodel;
        private List<ValidatorItem<T>> _list;

        private SmartPage _page;

        internal Validator(SmartPage page, T viewmodel)
        {
            _page = page;

            _list = new List<ValidatorItem<T>>();

            _viewmodel = viewmodel;

            _viewmodel.PropertyChanged += Viewmodel_PropertyChanged;
        }

        public void AddItem(Expression<Func<T, object>> memberLambda, FrameworkElement control = null)
        {
            var item = new ValidatorItem<T>(memberLambda, control);

            _list.Add(item);

            //Create a function to call: Func<T, object> aa = memberLambda.Compile();
        }

        public void AddItem(string validator_id, FrameworkElement control = null)
        {
            var item = new ValidatorItem<T>(validator_id, control);

            _list.Add(item);
        }

        /// <summary>
        /// Fire a validation event for each of the validation items.
        /// </summary>
        /// <returns>Returns true if all validation items are valid.</returns>
        public bool ValidateAll()
        {
            bool all_valid = true;

            for (int i = 0; i < _list.Count; i++)
            {
                var item = _list[i];

                bool item_valid = RaiseEvent(item);

                if (item_valid == false)
                    all_valid = false;
            }

            return all_valid;
        }

        private void Viewmodel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ValidatorItem<T> found = null;

            for (int i = 0; i < _list.Count; i++)
            {
                ValidatorItem<T> item = _list[i];

                if (item.PropertyName == e.PropertyName)
                {
                    found = item;
                    break;
                }
            }

            if (found != null)
            {
                RaiseEvent(found);
            }

        }

        /// <summary>
        /// Returns the final value of the ValidateEventArgs.IsValid property.
        /// </summary>
        private bool RaiseEvent(ValidatorItem<T> validator_item)
        {
            ValidateEventArgs<T> e = new ValidateEventArgs<T>(validator_item.PropertyName);

            e.Remark = "";

            ValidateEvent?.Invoke(this, _viewmodel, e);

            //if (validator_item.Control != null)
            //{
            //FormField ff = VenturaVisualTreeHelper.FindParent<FormField>(validator_item.Control);

            if (validator_item.FormField != null)
                validator_item.FormField.Remark = e.Remark;

            //}

            return e.IsValid;
        }


    }

    public abstract class ValidatorBase
    {
    }

}
