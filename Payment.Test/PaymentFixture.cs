using System.Collections.Generic;

namespace Payment.Test
{
    using NUnit.Framework;
    using Moq;
    
    using DomainModel.Models;
    using DomainModel.Shop;
    using Interfaces;
    using System;


    [TestFixture]
    public class PaymentFixture
    {
        private Mock<IPayment> _mock;


        [SetUp]
        public void Setup()
        {
            List<int> list = new List<int>();
            _mock = new Mock<IPayment>();
        }

        [TestCase(20)]
        public void WhenChoosePaymentMethodPayIsCalled(double amount)
        {

            var customer = new Customer("viorelyo", "Viorel", "Test", "Ismail Street, 2", "viorel@gmail.com", "1234");
            customer.PaymentMethod(_mock.Object, amount);

            _mock.Verify(m => m.pay(amount), Times.Once);
        }

        static object[] DivideCases =
        {
            new Mouse("SVEN RX-180",  "SVEN", CATEGORY.Periferice, 12,  null, "RX-180", "Cu fir", 800),
        };

        [Test, TestCaseSource("DivideCases")]
        public void WhenAddBuyItemToCart(Item item)
        {
           // var bi = new BuyItem(item);

           // Assert.AreNotEqual(bi, null);

        }


        public void WhenAddNullBuyItemToCart()
        {
           // var bi = new BuyItem(new Mouse(null, null, Item.CATEGORY.Periferice, 12, null, null, null, 800));

           // Assert.That(() => bi, Throws.Exception.TypeOf<ArgumentException>());
        }

        static object[] WhenCalculatePriceAndQuantityArgs =
        {
            0, 1, 2, 10, -10
        };

        [Test, TestCaseSource("WhenCalculatePriceAndQuantityArgs")]
        public void WhenCalculatePriceAndQuantity(int quantity)
        {
            Item keyboard = new Keyboard("Logitech G103", "Logitech", CATEGORY.Periferice, 29, null, "G103", "Cu fir", "USB");
            //BuyItem buyItem = new BuyItem(keyboard, quantity);


           // Assert.AreEqual(quantity * buyItem.Item.Price, buyItem.CalcPrice());
        }


    }
}
