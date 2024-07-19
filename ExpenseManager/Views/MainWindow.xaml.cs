using ExpenseManager.Controllers;
using ExpenseManager.Models;
using System.Windows;

namespace ExpenseManager.Views
{
    public partial class MainWindow : Window
    {
        private ExpenseController expenseController = new ExpenseController();

        public MainWindow()
        {
            InitializeComponent();
            UpdateExpenseList();
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            var addExpenseWindow = new AddExpenseWindow(expenseController);
            addExpenseWindow.ShowDialog();
            UpdateExpenseList();
        }

        private void EditExpense_Click(object sender, RoutedEventArgs e)
        {
            if (ExpenseListView.SelectedItem is Expense selectedExpense)
            {
                var editExpenseWindow = new EditExpenseWindow(expenseController, selectedExpense);
                editExpenseWindow.ShowDialog();
                UpdateExpenseList();
            }
        }

        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            if (ExpenseListView.SelectedItem is Expense selectedExpense)
            {
                expenseController.DeleteExpense(selectedExpense.Id);
                UpdateExpenseList();
            }
        }

        private void UpdateExpenseList()
        {
            ExpenseListView.ItemsSource = null;
            ExpenseListView.ItemsSource = expenseController.GetAllExpenses();
            TotalBalanceTextBlock.Text = "Total Balance: " + expenseController.GetTotalBalance().ToString("C");
        }
    }
}