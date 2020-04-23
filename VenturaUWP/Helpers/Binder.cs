using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ventura.Helpers
{
    public class Binder<T> : Binder where T : class
    {
        private List<Func<T, object>> _list = new List<Func<T, object>>();

        public override object[] GetValues(object o)
        {
            T typed = o as T;

            if (typed == null)
                throw new Exception($"Binder.GetValues must be called with type {typeof(T).Name}");

            object[] values = new object[_list.Count];

            for (int i = 0; i < _list.Count; i++)
            {
                values[i] = _list[i](typed);
            }

            return values;
        }

        public void Add(Expression<Func<T, object>> memberLambda)
        {
            Func<T, object> aa = memberLambda.Compile();

            _list.Add(aa);
        }

    }

    public abstract class Binder
    {
        public abstract object[] GetValues(object o);

    }

}
