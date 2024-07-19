using ExpenseManager.Controllers;
using ExpenseManager.Models;
using System;
using System.Windows;

namespace ExpenseManager.Views
{
    public partial class AddExpenseWindow : Window
    {
        private ExpenseController expenseController;

        public AddExpenseWindow(ExpenseController controller)
        {
            InitializeComponent();
            expenseController = controller;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var expense = new Expense
            {
                Id = new Random().Next(1, 1000), // simple ID generation
                Description = DescriptionTextBox.Text,
                Amount = decimal.Parse(AmountTextBox.Text),
                Date = DateTime.Now
            };

            expenseController.AddExpense(expense);
            this.Close();
        }
    }
}