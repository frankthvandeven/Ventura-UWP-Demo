using System;
using System.Linq.Expressions;
using Ventura.Helpers;
using Windows.UI.Xaml;

namespace Ventura.Controls
{
    public class ValidatorItem<T>
    {
        private ValidatorItemKind _kind;
        private string _validator_id;
        private readonly Expression<Func<T, object>> _memberLambda;
        private FrameworkElement _control;
        private FormField _formfield;
        private string _property_name;

        private string _remark;

        public ValidatorItem(Expression<Func<T, object>> memberLambda, FrameworkElement control)
        {
            _kind = ValidatorItemKind.ViewModelProperty;

            _memberLambda = memberLambda;
            _property_name = LambdaHelper.GetMemberName(memberLambda.Body);

            if (control is FormField)
            {
                _control = null;
                _formfield = (FormField)control;
            }
            else
            {
                // FindParent returns null if not found.
                _control = control;
                _formfield = VenturaVisualTreeHelper.FindParent<FormField>(control);
            }


        }

        public ValidatorItem(string validator_id, FrameworkElement control)
        {
            if (validator_id == null)
                throw new ArgumentNullException(nameof(validator_id));

            _kind = ValidatorItemKind.ValidatorId;

            _validator_id = validator_id;

            if (control is FormField)
            {
                _control = null;
                _formfield = (FormField)control;
            }
            else
            {
                // FindParent returns null if not found.
                _control = control;
                _formfield = VenturaVisualTreeHelper.FindParent<FormField>(control);
            }

        }

        public Expression<Func<T, object>> MemberLambda
        {
            get { return _memberLambda; }
        }

        public string PropertyName
        {
            get { return _property_name; }
        }

        public FrameworkElement Control
        {
            get { return _control; }
        }

        public FormField FormField
        {
            get { return _formfield; }
        }

    }

    public enum ValidatorItemKind
    {
        ViewModelProperty,
        ValidatorId
    }


}
