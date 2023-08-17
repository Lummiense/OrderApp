using OrderApp.Client.Infrastructure.Command;
using OrderApp.Client.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OrderApp.Client.ViewModels
{
    /// <summary>
    /// ModelView для окна ввода логина и пароля.
    /// </summary>
    internal class LoginWindowViewModel:ViewModel
    {
        #region Свойства элементов окна авторизации.
        private string _title = "Окно входа";
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        private string _label = "Введите логин и пароль";
        /// <summary>
        /// Текст над полями ввода логина и пароля.
        /// </summary>
        public string Label
        {
            get => _label;
            set => Set(ref _label, value);
        }
        private string _login = "Логин";
        /// <summary>
        /// Текст в поле ввода логина.
        /// </summary>
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }
        private string _password = "Пароль";
        /// <summary>
        /// Текст в поле ввода логина.
        /// </summary>
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }
        private string _button = "Войти";
        /// <summary>
        /// Текст на кнопке входа.
        /// </summary>
        public string Button
        {
            get => _button;
            set => Set(ref _button, value);
        }
        #endregion
    }
}
