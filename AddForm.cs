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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public delegate void AddItemDelegate(Book item);

        public AddItemDelegate AddItemCallback;
      
        private void addButton_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.name = nameBox.Text;
            book.author = authorBox.Text;
            DateTime date = new DateTime(int.Parse(yearBox.Text),DateTime.Now.Month,DateTime.Now.Day,4,5,6);
            book.year = date;
            AddItemCallback(book);
            this.Close();
        }       
    }
}
