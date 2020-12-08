//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BookShopping.Models.ShoppingModel
//{

//    public class SaleModel
//    {
//        /// SaleModel instance alındığında list tipinde olan özellikler null olmaması için cons kullandım.
//        /// Aynı zamanda burda tabi ki farklı işlemlerde yapılabilir..
//        public SaleModel()
//        {
//            Products = new List();
//            Payments = new List();
//            Discounts = new List();
//        }
//        #region Properties
//        public string Code { get; set; }
//        public List Products { get; set; }
//        public decimal GrandTotal
//        {
//            get
//            {
//                return Products.Sum(s => s.Price);
//            }
//        }
//        public decimal TotalQuantity
//        {
//            get
//            {
//                if (Products.Any())
//                    return Products.Sum(s => s.Quantity);

//                return decimal.Zero;
//            }
//        }
//        public List Payments { get; set; }

//        /// Yapılan ödemelerin toplamı
//        public decimal TotalPayment
//        {
//            get
//            {
//                if (Payments.Any())
//                    return Payments.Sum(s => s.Price);
//                return decimal.Zero;
//            }
//        }
//        public List Discounts { get; set; }

//        /// Yapılan indirimlerin toplamı
//        public decimal TotalDiscount
//        {
//            get
//            {
//                if (Discounts.Any())
//                    return Discounts.Sum(s => s.Price);
//                return decimal.Zero;
//            }
//        }

//        /// Yapılan ödemeler ile toplam tutarın farkı.
//        /// Kalan tutar

//        public decimal RemainingPrice
//        {
//            get
//            {
//                return GrandTotal - (TotalPayment + TotalDiscount);
//            }
//        }
//        #endregion
//        #region Methods

//        /// İlgili SaleModel'e bir satır ürün ekler..

//        public void AddProduct(Product product)
//        {
//            this.Products.Add(product);
//        }

//        /// İlgili SaleModel'e bir satır ödeme ekler..

//        public void AddPayment(Payment payment)
//        {
//            this.Payments.Add(payment);
//        }

//        /// İlgili SaleModel'e bir satır indirim ekler..

//        public void AddDiscount(Discount discount)
//        {
//            this.Discounts.Add(discount);
//        }
//        #endregion
//    }
//}
//}
