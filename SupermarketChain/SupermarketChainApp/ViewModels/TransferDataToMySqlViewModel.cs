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
using SupermarketChainMySQL.Data;
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

            try
            {              
                this.TransferVendors();
                this.mysqlData.Save();
                this.TransferProducts();
 
                this.mysqlData.Save();
                this.Message = "Transfer successful!";
            }
            catch (Exception ex)
            {
                this.Message = "Transfer failed!";
                this.Message = ex.Message;
            }
            finally
            {
                this.transferingData = false;
            }
        }

        private void TransferVendors()
        {
            var vendors = this.sqlServerData.VendorRepository.GetVendorsWithExpenses();

            foreach (var vendor in vendors)
            {
                var existingVendor = this.mysqlData.VendorRepository.Get(
                    v => v.VendorName.Equals(vendor.VendorName)).FirstOrDefault();

                if (existingVendor == null)
                {
                    this.mysqlData.VendorRepository.Add(new Vendor()
                    {
                        VendorName = vendor.VendorName,
                        Expenses = vendor.Expenses
                    });
                }
                else if (!existingVendor.Expenses.Equals(vendor.Expenses))
                {
                    existingVendor.Expenses = vendor.Expenses;
                    this.mysqlData.VendorRepository.Update(existingVendor);
                }
            }
        }

        private void TransferProducts()
        {
            var products = this.sqlServerData.ProductRepository.GetProductsWithIncomes();

            foreach (var product in products)
            {
                var existingProduct = this.mysqlData.ProductRepository.Get(
                    p => p.ProductName.Equals(product.ProductName)).FirstOrDefault();

                if (existingProduct == null)
                {
                    this.mysqlData.ProductRepository.Add(new Product()
                    {
                        ProductName = product.ProductName,
                        VendorId = this.mysqlData.VendorRepository
                            .Get(v => v.VendorName.Equals(product.VendorName))
                            .FirstOrDefault().VendorId,
                        Income = product.Incomes
                    });
                } 
                else if (!existingProduct.Income.Equals(product.Incomes))
                {
                    existingProduct.Income = product.Incomes;
                    this.mysqlData.ProductRepository.Update(existingProduct);
                }
            }
        }

        private bool CanTransferData()
        {
            return !this.transferingData;
        } 
    }
}
