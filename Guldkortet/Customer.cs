using System.Collections.Generic;

namespace Guldkortet
{
    public class Customer
    {
        public string customerNumber { get; set; } //egenskaper för Customer-klassen
        public string customerName { get; set; }
        public string customerCity { get; set; }

        public override string ToString()
        {
            return customerNumber + " " + customerName + " " + customerCity; //ToString-metod för vår Customer-klass för enkel utmatning (används tyvärr inte då det blev knepigt att dela upp)
        }
    }
}
