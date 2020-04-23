using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;

// https://www.fabiocozzolino.eu/my-viewmodel-base-class-implementation/

namespace Ventura
{
    public class ViewmodelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
        private Dictionary<string, object> _properties = new Dictionary<string, object>();
        private const string EXECUTECOMMAND_SUFFIX = "_ExecuteCommand";
        private const string CANEXECUTECOMMAND_SUFFIX = "_CanExecuteCommand";

        private bool _ismodelmodified;

        public bool IsModelModified
        {
            get { return _ismodelmodified; }
        }

        public void ResetModelModified()
        {
            _ismodelmodified = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsModelModified)));
        }

        /// <summary>
        /// You can indicate that all properties on the object have changed by
        /// using String.Empty for the propertyName argument.
        /// Note that you cannot use null for this like you can in WPF.
        /// </summary>
        public /* virtual */ void NotifyPropertyChanged([CallerMemberName] string property_name = null)
        {
            if (property_name == null)
                throw new ArgumentNullException();

            _ismodelmodified = true;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsModelModified)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }

        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (!_properties.ContainsKey(propertyName))
            {
                _properties.Add(propertyName, default(T));
            }

            var oldValue = GetValue<T>(propertyName);
            if (!EqualityComparer<T>.Default.Equals(oldValue, value))
            {
                _properties[propertyName] = value;
                NotifyPropertyChanged(propertyName);
            }
        }

        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (!_properties.ContainsKey(propertyName))
            {
                return default(T);
            }
            else
            {
                return (T)_properties[propertyName];
            }
        }

        public ViewmodelBase()
        {
            this._commands =
                this.GetType().GetTypeInfo().DeclaredMethods
                .Where(dm => dm.Name.EndsWith(EXECUTECOMMAND_SUFFIX))
                .ToDictionary(k => GetCommandName(k), v => CreateCommand(v));
        }

        private string GetCommandName(MethodInfo mi)
        {
            return mi.Name.Replace(EXECUTECOMMAND_SUFFIX, "");
        }

        private ICommand CreateCommand(MethodInfo mi)
        {
            var canExecute = this.GetType().GetTypeInfo().GetDeclaredMethod(GetCommandName(mi) + CANEXECUTECOMMAND_SUFFIX);

            var executeAction = (Action<object>)mi.CreateDelegate(typeof(Action<object>), this);

            var canExecuteAction = canExecute != null ? (Func<object, bool>)canExecute.CreateDelegate(typeof(Func<object, bool>), this) : state => true;

            return new Command(executeAction, canExecuteAction);
        }

        //public ICommand this[string name]
        //{
        //    get { return _commands[name]; }
        //}

        public ICommand Command(string name)
        {
            return _commands[name];
        }

    }
}


#if kllkjljklkj
        public void DisplayInvocationList()
        {
            var aa = this.PropertyChanged.GetInvocationList();

            var bb = aa.Count();

            Debug.WriteLine("List length :" + bb.ToString());

        }
#endif
