using ExpenseManager.Controllers;
using ExpenseManager.Models;
using System.Windows;

namespace ExpenseManager.Views
{
    public partial class EditExpenseWindow : Window
    {
        private ExpenseController expenseController;
        private Expense expense;

        public EditExpenseWindow(ExpenseController controller, Expense existingExpense)
        {
            InitializeComponent();
            expenseController = controller;
            expense = existingExpense;

            DescriptionTextBox.Text = expense.Description;
            AmountTextBox.Text = expense.Amount.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            expense.Description = DescriptionTextBox.Text;
            expense.Amount = decimal.Parse(AmountTextBox.Text);
            expense.Date = DateTime.Now;

            expenseController.EditExpense(expense);
            this.Close();
        }
    }
}