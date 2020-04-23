using System;
using System.Linq.Expressions;
using Ventura.Helpers;

namespace Ventura.Controls
{

    public class ValidateEventArgs<T> : ValidateEventArgsBase
    {
        private string _property_name;

        internal ValidateEventArgs(string property_name)
        {
            _property_name = property_name;
        }

        public bool IsProperty(Expression<Func<T, object>> member_lambda)
        {
            string compare_name = LambdaHelper.GetMemberName(member_lambda.Body);

            if (compare_name == _property_name)
                return true;

            return false;
        }

    }

    public abstract class ValidateEventArgsBase
    {
        private bool _isvalid;
        private string _remark;

        public ValidateEventArgsBase()
        {
            _isvalid = false;
            _remark = "";
        }

        public bool IsValid
        {
            get { return _isvalid; }
            set { _isvalid = value; }
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }


    }
}


