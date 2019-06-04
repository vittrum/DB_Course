using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Contracts;

namespace DB_Course
{
    class ErrorProtector
    {
        public ErrorProtector() { }
        #region Messages
        public void WrongValue() => MessageBox.Show("Значение введено неверно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void EmptyBox() => MessageBox.Show("Поле не может быть пустым!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void WrongPassword() => MessageBox.Show("Неверный пароль!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void MustBeInteger() => MessageBox.Show("Значение должно быть целым числом!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void MustBeNumber() => MessageBox.Show("Значение должно быть числового типа!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void MustBeString() => MessageBox.Show("Значения могут быть только строчного типа!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void Error() => MessageBox.Show("Ошибка при вводе!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void AccessError() => MessageBox.Show("Нет прав доступа!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        #endregion

        #region Staff Validation
        public void Protected_Staff_Insert(Factory factory, string name, string lastname, string patronymic, string education,
                                string phone, string registration, string pass, string type)
        {
            AdministratorRequests administratorRequest = new AdministratorRequests();
            long parser;
            Contract.Requires(name != null && name.GetType() == typeof(string));
            Contract.Requires(lastname != null && lastname.GetType() == typeof(string));
            Contract.Requires(patronymic != null && patronymic.GetType() == typeof(string));
            Contract.Requires(education != null && education.GetType() == typeof(string));
            Contract.Requires(phone != null && long.TryParse(phone, out parser));
            Contract.Requires(registration != null);
            Contract.Requires(pass != null);
            Contract.Requires(factory != null);
            Contract.Requires(factory.RepositoryStaff != null);
            administratorRequest.Add_Staff(factory, name, lastname, patronymic,
                education, phone, registration, pass, type);
        }
        #endregion
        /* 
         * Обработка ошибки для вывода сообщения
         * Contract.ContractFailed += (sender, e) =>
        {
        Console.WriteLine(e.Message);
        e.SetHandled();
        };
        */
    }
}
