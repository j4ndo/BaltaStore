using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        var name = new Name("Janderson", "Fonseca");
        var document = new Document("0123456789");
        var email = new Email("janderson-fonseca@hotmail.com");
        var c = new Customer(name, document, email, "84999887766");
        var mouse = new Product("Mouse","Rato","image.png", 59.99M, 10);
        var teclado = new Product("Teclado","teclado","image.png", 159.99M, 10);
        var impressora = new Product("Impressora","Impressora","image.png", 359.99M, 10);
        var cadeira = new Product("Cadeira","Cadeira","image.png", 559.99M, 10);
            
        var order = new Order(c);
        order.AddItem(new OrderItem(mouse, 5));
        order.AddItem(new OrderItem(teclado, 5));
        order.AddItem(new OrderItem(impressora, 5));
        order.AddItem(new OrderItem(cadeira, 5));

        // Realiza Pedido
        order.Place();
        order.Pay();
        order.Ship();
        order.Cancel();
        }
    }
}
