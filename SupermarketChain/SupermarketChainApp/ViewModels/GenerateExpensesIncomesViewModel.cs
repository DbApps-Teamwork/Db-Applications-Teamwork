using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using GenerateIncomesExensesReports;
using GenerateIncomesExensesReports.Contracts;
using Ninject.Selection;
using SupermarketChainApp.Commands;
using SupermarketChainMySQL.DataAccess.Contracts;
using SupermarketChainSQLite.DataAccess.Contracts;
using SupermarketChainSQLServer.DataAccess.Contracts;
using WinForms = System.Windows.Forms;

namespace SupermarketChainApp.ViewModels
{
    public class GenerateExpensesIncomesViewModel : ViewModelBase
    {
        private const decimal DefaultTax = 0.2m;
        private const string DefaultExtension = "xlsx";
        private ISupermarketChainMySQLData mysqlData;
        private ISupermarketChainSQLiteData sqliteData;
        private IIncomesExpensesGenerator generator;
        private ICommand openFileDialogCommand;
        private ICommand generateIncomesExpensesCommand;
        private string path;
        private string fileName;
        private bool generating;

        public GenerateExpensesIncomesViewModel(
            ISupermarketChainMySQLData mysqlData,
            ISupermarketChainSQLiteData sqliteData,
            IIncomesExpensesGenerator generator)
        {
            this.mysqlData = mysqlData;
            this.sqliteData = sqliteData;
            this.generator = generator;
        }

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

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                if (this.fileName != null && this.fileName.Equals(value))
                {
                    return;
                }
                this.fileName = value;
                this.OnPropertyChanged("FileName");
            }
        }

        public ICommand GenerateIncomesExpensesCommand
        {
            get
            {
                if (this.generateIncomesExpensesCommand == null)
                {
                    this.generateIncomesExpensesCommand = new RelayCommand(
                        this.GenerateIncomesExpenses, this.CanGenerate);
                }
                return this.generateIncomesExpensesCommand;
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

        private void GenerateIncomesExpenses()
        {
            this.generating = true;
            this.Message = "Generating...";

            try
            {
                var filePath = String.Format("{0}\\{1}.{2}", this.Path, this.FileName, DefaultExtension);
                var taxes = this.sqliteData.ProductTaxRepository.Get();
                var products = this.mysqlData.ProductRepository.Get(properties: "Vendor");

                var vendorFinances =
                    from p in products
                    join t in taxes on p.ProductName equals t.ProductName into vf
                    from joined in vf.DefaultIfEmpty()
                    group new {p, joined} by new {p.Vendor.VendorName, p.Vendor.Expenses}
                    into grouped
                    select new IncomesExpensesDto()
                    {
                        VendorName = grouped.Key.VendorName,
                        Expenses = grouped.Key.Expenses,
                        Incomes = grouped.Sum(g => g.p.Income),
                        TotalTaxes = grouped.Sum(g => g.p.Income*(g.joined == null ? DefaultTax : g.joined.Tax))
                    };

                this.generator.GenerateIncomesExpenses(vendorFinances, filePath);
            }
            catch (Exception)
            {
                this.generating = false;
                this.Message = "Generation failed!";
            }
            finally
            {
                this.generating = false;
            }

            this.Message = "Incomes and expenses generated successfully!";
        }

        private bool CanGenerate()
        {
            return !this.generating;
        }

        private void FileDialog()
        {
            var dialog = new WinForms.FolderBrowserDialog();
            dialog.ShowDialog();
            this.Path = dialog.SelectedPath;
        }
    }
}
