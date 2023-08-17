using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Client.ViewModels.Base
{
    /// <summary>
    /// Базовый класс ViewModel.
    /// </summary>
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Генератор вызова события.
        /// </summary>
        /// <param name="propertyName">Имя метода, который вызывает событие.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Изменение свойства поля.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Ссылка на поле свойства.</param>
        /// <param name="value">Значение свойства, которое нужно задать.</param>
        /// <param name="propertyName">Имя передаваемого свойства.</param>
        protected virtual bool Set<T>(ref T field,T value, [CallerMemberName] string propertyName = null)
        {
            if(Equals(field,value)) return false;
            field=value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
