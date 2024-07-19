using ExpenseManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManager.Controllers
{
    public class ExpenseController
    {
        private List<Expense> expenses = new List<Expense>();

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        public void EditExpense(Expense expense)
        {
            var existingExpense = expenses.FirstOrDefault(e => e.Id == expense.Id);
            if (existingExpense != null)
            {
                existingExpense.Description = expense.Description;
                existingExpense.Amount = expense.Amount;
                existingExpense.Date = expense.Date;
            }
        }

        public void DeleteExpense(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expenses.Remove(expense);
            }
        }

        public List<Expense> GetAllExpenses()
        {
            return expenses;
        }

        public decimal GetTotalBalance()
        {
            return expenses.Sum(e => e.Amount);
        }
    }
}