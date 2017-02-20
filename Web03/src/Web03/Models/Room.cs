using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web03.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string CondoName { get; set; }
        public double Area { get; set; }
        public decimal RentalFee { get; set; }
        public bool IsReserved { get; private set; } = false;

        public void Reserved()
        {
            IsReserved = true;
        }

        public void CancelReserved()
        {
            IsReserved = false;
        }
    }
}
