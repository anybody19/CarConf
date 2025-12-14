using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConf.Models
{
    public class CarConfiguration
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Color { get; set; }
        public List<string> Options { get; set; } = new List<string>();

        public decimal BasePrice { get; set; }
        public decimal EnginePrice { get; set; }
        public decimal ColorPrice { get; set; }
        public decimal OptionsPrice { get; set; }

        public decimal InitialPaymentPercent { get; set; }
        public int CreditMonths { get; set; }
        public decimal MonthlyPayment { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public decimal TotalPrice()
        {
            return BasePrice + EnginePrice + ColorPrice + OptionsPrice;
        }
    }
}