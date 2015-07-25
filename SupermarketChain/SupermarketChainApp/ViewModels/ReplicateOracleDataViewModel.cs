using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SupermarketChainApp.Commands;
using SupermarketChainOracle.DataAccess.Contracts;
using SupermarketChainSQLServer.Data;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainApp.ViewModels
{
    public class ReplicateOracleDataViewModel : ViewModelBase
    {
        private readonly ISupermarketChainSQLServerData sqlServerData;
        private readonly ISupermarketChainOracleData oracleData;
        private ICommand transferDataCommand;
        private bool transferingData;

        public ReplicateOracleDataViewModel(
            ISupermarketChainSQLServerData sqlServerData,
            ISupermarketChainOracleData oracleData)
        {
            this.sqlServerData = sqlServerData;
            this.oracleData = oracleData;
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
            try
            {
                this.transferingData = true;
                this.Message = "Transfering data, please wait...";
                this.TransferMeasures();
                this.TransferVendors();
                this.sqlServerData.Save();
                this.TransferProducts();
            
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

        private void TransferMeasures()
        {
            var measures = this.oracleData.MeasureRepository.Get();

            foreach (var measure in measures)
            {
                var existingMeasure = this.sqlServerData.MeasureRepository.Get(
                    m => m.MeasureName.Equals(measure.MeasureName)).FirstOrDefault();
                if (existingMeasure == null)
                {
                    this.sqlServerData.MeasureRepository.Add(new Measure()
                    {
                        MeasureName = measure.MeasureName
                    });
                }
            }
        }

        private void TransferVendors()
        {
            var vendors = this.oracleData.VendorRepository.Get();

            foreach (var vendor in vendors)
            {
                var existingVendor = this.sqlServerData.VendorRepository.Get(
                    v => v.VendorName.Equals(vendor.VendorName)).FirstOrDefault();
                if (existingVendor == null)
                {
                    this.sqlServerData.VendorRepository.Add(new Vendor()
                    {
                        VendorName = vendor.VendorName
                    });
                }
            }
        }

        private void TransferProducts()
        {
            var products = this.oracleData.ProductRepository.Get(
                properties: "Vendor,Measure");

            foreach (var product in products)
            {
                var existingProduct = this.sqlServerData.ProductRepository.Get(
                    p => p.ProductName.Equals(product.ProductName)).FirstOrDefault();
                if (existingProduct == null)
                {
                    this.sqlServerData.ProductRepository.Add(new Product()
                    {
                        ProductName = product.ProductName,
                        Price = product.Price,
                        MeasureId = this.sqlServerData.MeasureRepository
                            .Get(m => m.MeasureName.Equals(product.Measure.MeasureName))
                            .FirstOrDefault().MeasureId,
                        VendorId = this.sqlServerData.VendorRepository
                            .Get(v => v.VendorName.Equals(product.Vendor.VendorName))
                            .FirstOrDefault().VendorId
                    });
                }
            }
        }

        private bool CanTransferData()
        {
            return !this.transferingData;
        }      
    }
}
