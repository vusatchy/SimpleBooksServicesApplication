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
    public partial class MainForm : Form
    {
        private BookController controller = new BookController();

        public MainForm()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            fillGridWithData(controller.getAllBooks());
        }

        private void fillGridWithData(List<Book> books)
        {
            foreach (Book book in books)
            {
                string[] row = { book.id.ToString(), book.name, book.author, book.year.Year.ToString() };
                dataGridView.Rows.Add(row);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                dataGridView.Rows.Clear();
                fillGridWithData(controller.getBooksByNameLike(searchTextBox.Text));
            }
        }

       

        private void loadButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            loadData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            form.Show();
            form.AddItemCallback = new AddForm.AddItemDelegate(this.addEvent);
        }



        private void addEvent(Book book)
        {
            controller.addBook(book);
            dataGridView.Rows.Clear();
            loadData();
        }

        private void deleteEvent(Book book)
        {
            controller.deleteBook(book);
            dataGridView.Rows.Clear();
            loadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteForm form = new DeleteForm();
            form.Show();
            form.DeleteItemCallback = new DeleteForm.DeleteItemDelegate(this.deleteEvent);
        }

        private void idToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            fillGridWithData(controller.getSortedListOfBooksById());
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            fillGridWithData(controller.getSortedListOfBooksByName());
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            fillGridWithData(controller.getSortedListOfBooksByAuthor());
        }

        private void yearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            fillGridWithData(controller.getSortedListOfBooksByYear());
        }
    }
}
