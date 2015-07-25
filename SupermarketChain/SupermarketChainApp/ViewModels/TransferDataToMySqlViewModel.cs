using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SupermarketChainApp.Commands;
using SupermarketChainMySQL.DataAccess.Contracts;
using SupermarketChainOracle.DataAccess.Contracts;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainApp.ViewModels
{
    public class TransferDataToMySqlViewModel : ViewModelBase
    {
        private readonly ISupermarketChainSQLServerData sqlServerData;
        private readonly ISupermarketChainMySQLData mysqlData;
        private ICommand transferDataCommand;
        private bool transferingData;

        public TransferDataToMySqlViewModel(
            ISupermarketChainSQLServerData sqlServerData,
            ISupermarketChainMySQLData mysqlData)
        {
            this.sqlServerData = sqlServerData;
            this.mysqlData = mysqlData;
            this.transferingData = false;
        }

        public ICommand TransferDataCommand
        {
            get
            {
                if(this.transferDataCommand == null)
                {
                    this.transferDataCommand = new RelayCommand(
                        this.TransferData, this.CanTransferData);
                }
                return this.transferDataCommand;
            }
        }

        private void TransferData()
        {
            this.transferingData = true;
            this.Message = "Transfering data, please wait...";
            this.TransferVendors();
            this.TransferProducts();

            try
            {
                this.sqlServerData.Save();
                this.Message = "Transfer successful!";
            }
            catch (InvalidOperationException ex)
            {
                this.Message = "Transfer failed!";
            }
            catch (DbUpdateException ex)
            {
                this.Message = "Transfer failed!";
            }
            catch (DbEntityValidationException ex)
            {
                this.Message = "Transfer failed!";
            }
            catch (NotSupportedException ex)
            {
                this.Message = "Transfer failed!";
            }
            finally
            {
                this.transferingData = false;
            }
        }

        private void TransferVendors()
        {
            
        }

        private void TransferProducts()
        {
            
        }

        private bool CanTransferData()
        {
            return !this.transferingData;
        } 
    }
}
