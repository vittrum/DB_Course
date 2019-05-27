using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Course
{
    class ErrorProtector
    {
        public ErrorProtector() { }
        public void WrongValue() => MessageBox.Show("Значение введено неверно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void EmptyBox() => MessageBox.Show("Поле не может быть пустым!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void WrongPassword() => MessageBox.Show("Неверный пароль!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void MustBeInteger() => MessageBox.Show("Значение должно быть целым числом!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void MustBeNumber() => MessageBox.Show("Значение должно быть числового типа!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void MustBeString() => MessageBox.Show("Значения могут быть только строчного типа!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void Error() => MessageBox.Show("Ошибка при вводе!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void AccessError() => MessageBox.Show("Нет прав доступа!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
    }
}
