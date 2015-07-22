using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using SalesReportsGenerator.Contracts;
using SupermarketChainApp.Commands;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainApp.ViewModels
{
    public class GenerateSalesReportsViewModel : ViewModelBase
    {
        private ISalesReportsGenerator generator;
        private ISupermarketChainSQLServerData sqlServerData;
        private ICommand openFileDialogCommand;
        private ICommand generateReportsCommand;
        private DateTime startDate;
        private DateTime endDate;
        private string path;
        private string fileName;
        private bool generatingReports;

        public GenerateSalesReportsViewModel(
            ISupermarketChainSQLServerData sqlServerData, 
            ISalesReportsGenerator generator)
        {
            this.sqlServerData = sqlServerData;
            this.generator = generator;
            this.generatingReports = false;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
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

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                if (this.startDate.Equals(value))
                {
                    return;
                }
                this.startDate = value;
                this.OnPropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                if (this.endDate.Equals(value))
                {
                    return;
                }
                this.endDate = value;
                this.OnPropertyChanged("EndDate");
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

        public ICommand GenerateReportsCommand
        {
            get
            {
                if (this.generateReportsCommand == null)
                {
                    this.generateReportsCommand = new RelayCommand(
                        this.GenerateReports, this.CanGenerateReports);
                }
                return this.generateReportsCommand;
            }
        }

        private void GenerateReports()
        {
            this.generatingReports = true;
            this.Message = "Generating reports, please wait...";

            var salesByVendor = this.sqlServerData.SaleRepository.GetSalesByVendor(this.StartDate, this.EndDate);
            this.generator.Writer.Path = this.Path + "\\" + this.FileName;
            var n = this.Path + "\\" + this.FileName;
            this.generator.GenerateSalesReports(salesByVendor);

            this.Message = "Reports generated successfully!";
            this.generatingReports = false;
        }

        private bool CanGenerateReports()
        {
            return !this.generatingReports;
        }

        private void FileDialog()
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            this.Path = dialog.FileName;
        }
    }
}
