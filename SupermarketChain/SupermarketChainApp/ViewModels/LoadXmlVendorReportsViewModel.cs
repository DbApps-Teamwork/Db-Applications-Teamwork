using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpenseDataLoader.Contracts;
using ExpenseDataLoader.Readers;
using Microsoft.Win32;
using SupermarketChainApp.Commands;
using SupermarketChainSQLServer.Data;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainApp.ViewModels
{
    public class LoadXmlVendorReportsViewModel : ViewModelBase
    {
        private ISupermarketChainSQLServerData sqlServerData;
        private IExpenseLoader expenseLoader;
        private ICommand openFileDialogCommand;
        private ICommand loadVendorReportsCommand;
        private bool loadingReports;
        private string path;

        public LoadXmlVendorReportsViewModel(
            ISupermarketChainSQLServerData sqlServerData,
            IExpenseLoader expenseLoader)
        {
            this.sqlServerData = sqlServerData;
            this.expenseLoader = expenseLoader;
            this.loadingReports = false;
            this.UnexistingVendors = new ObservableCollection<string>();
        }

        public ObservableCollection<string> UnexistingVendors { get; set; }

        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                if (this.path != null && this.path.Equals(value))
                {
                    return;
                }
                this.path = value;
                this.OnPropertyChanged("Path");
            }
        }

        public ICommand OpenFileDialogCommand
        {
            get
            {
                if (this.openFileDialogCommand == null)
                {
                    this.openFileDialogCommand = new RelayCommand(this.FileDialog);
                }
                return this.openFileDialogCommand;
            }
        }

        public ICommand LoadVendorReportsCommand
        {
            get
            {
                if (this.loadVendorReportsCommand == null)
                {
                    this.loadVendorReportsCommand = new RelayCommand(
                        this.LoadVendorReports, this.CanLoadReports);
                }
                return this.loadVendorReportsCommand;
            }
        }

        private void LoadVendorReports()
        {
            this.Message = "Importing vendor expenses reports, please wait...";
            this.loadingReports = false;

            try
            {
                this.expenseLoader.Reader.Path = this.Path;
                var expensesReports = this.expenseLoader.LoadExpenses();

                foreach (var expense in expensesReports)
                {
                    var vendor = sqlServerData.VendorRepository
                        .Get(exp => exp.VendorName.Equals(expense.VendorName)).FirstOrDefault();

                    if (vendor != null)
                    {
                        this.sqlServerData.ExpenseRepository.Add(new Expense()
                        {
                            VendorId = vendor.VendorId,
                            ExpenseDate = expense.ExpenseDate,
                            ExpenseSum = expense.ExpenseSum
                        });
                    }
                    else
                    {
                        this.UnexistingVendors.Add(
                            String.Format("Vendor with name: {0} does not exists", expense.VendorName));
                    }
                }

                this.sqlServerData.Save();
                this.Message = "Import successful!";
            }
            catch (Exception)
            {
                this.Message = "Import failed!";
            }
            finally
            {
                this.loadingReports = false;
            }
        }

        private bool CanLoadReports()
        {
            return !this.loadingReports;
        }

        private void FileDialog()
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            this.Path = dialog.FileName;
        }
    }
}
