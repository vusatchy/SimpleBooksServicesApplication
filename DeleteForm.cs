using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work1
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        public delegate void DeleteItemDelegate(Book item);

        public DeleteItemDelegate DeleteItemCallback;

            
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.id = int.Parse(deleteBox.Text);
            DeleteItemCallback(book);
            this.Close();
        }

    }
}
