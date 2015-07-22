using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ExpenseDataLoader.Contracts;
using SupermarketChainSQLServer.Data;

namespace ExpenseDataLoader.Readers
{
    public class XmlExpenseReader : IExpensesReader
    {
        private const string DefaultExpenseDateFormat = "MMM-yyyy";

        public XmlExpenseReader(string path = "", string dateFormat = DefaultExpenseDateFormat)
        {
            this.Path = path;
            this.ExpenseDateFormat = dateFormat;
        }

        public string Path { get; set; }

        public string ExpenseDateFormat { get; private set; }

        public IEnumerable<ExpenseDto> ReadExpenses()
        {
            var expenses = new List<ExpenseDto>();

            using (XmlReader reader = XmlReader.Create(this.Path))
            {
                var xml = XElement.Load(reader);
                var vendors = xml.Descendants("vendor");
                
                foreach (var vendor in vendors)
                {
                    var vendorName = vendor.Attribute("name").Value;
                    var vendorExpenses = vendor.Descendants("expenses");

                    foreach (var vendorExpense in vendorExpenses)
                    {
                        var dateString = vendorExpense.Attribute("month").Value;
                        var date = this.ParseExpenseDate(dateString);
                        var sum = decimal.Parse(vendorExpense.Value);
                        var expense = new ExpenseDto()
                        {
                            ExpenseDate = date,
                            ExpenseSum = sum,
                            VendorName = vendorName
                        };
                        expenses.Add(expense);
                    }
                }
            }
            return expenses;
        }

        private DateTime ParseExpenseDate(string dateString)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var date = DateTime.ParseExact(dateString, this.ExpenseDateFormat, provider);
            return date;
        }
    }
}
