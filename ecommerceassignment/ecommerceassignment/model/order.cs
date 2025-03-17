//using ecommerceassignment.model

namespace ecommerceassignment.model
{
    public class order
    {
        public int? OrderNo { get; set; }
        public DateTime orderDate { get; set; }
        public double invoicePrice { get; set; }
        List<product> Products { get; set; } 
    }
}
