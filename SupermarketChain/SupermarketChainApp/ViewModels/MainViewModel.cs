using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(ISupermarketChainSQLServerData sqlServerData)
        {
            this.Tabs = new ObservableCollection<ViewModelBase>()
            {
                ObjectFactory.Get<ReplicateOracleDataViewModel>(),
                ObjectFactory.Get<LoadExcelReportsViewModel>()
            };
        }

        public ObservableCollection<ViewModelBase> Tabs { get; set; }
    }
}
