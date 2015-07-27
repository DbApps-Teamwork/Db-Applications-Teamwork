using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using ExcelSalesReports.DataAccess.Contracts;
using Microsoft.Win32;
using SupermarketChainApp.Commands;
using SupermarketChainSQLServer.Data;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainApp.ViewModels
{
    public class LoadExcelReportsViewModel : ViewModelBase
    {
        private readonly ISupermarketChainSQLServerData sqlServerData;
        private readonly IExcelReportsData excelReportsData;
        private ICommand loadReportsCommand;
        private ICommand openFileDialogCommand;
        private bool loadingReports;
        private string path;

        public LoadExcelReportsViewModel(
            ISupermarketChainSQLServerData sqlServerData,
            IExcelReportsData excelReportsData)
        {
            this.sqlServerData = sqlServerData;
            this.excelReportsData = excelReportsData;
            this.UnexistingProducts = new ObservableCollection<string>();
        }

        public ObservableCollection<string> UnexistingProducts { get; set; }

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

        public ICommand LoadReportsCommand
        {
            get
            {
                if (this.loadReportsCommand == null)
                {
                    this.loadReportsCommand = new RelayCommand(
                        this.LoadReports, this.CanLoadReports);
                }
                return this.loadReportsCommand;
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

        private void LoadReports()
        {
            this.loadingReports = true;
            this.Message = "Importing reports, please wait...";

            using (TransactionScope tran = new TransactionScope())
            {
                var reports = this.excelReportsData.GetSalesReports(this.Path);
                foreach (var report in reports)
                {
                    var product = this.sqlServerData.ProductRepository
                        .Get(p => p.ProductName.Equals(report.ProductName))
                        .FirstOrDefault();

                    if (product != null)
                    {
                        this.sqlServerData.SaleRepository.Add(new Sale()
                        {
                            Location = report.Location,
                            Price = report.UnitPrice,
                            Quantity = report.Quantity,
                            SaleDate = report.SaleDate,
                            ProductId = product.ProductId
                        });
                    }
                    else
                    {
                        this.UnexistingProducts.Add(
                            String.Format("Product with name {0} does not exists", report.ProductName));
                    }
                }

                try
                {
                    this.sqlServerData.Save();
                    tran.Complete();
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
