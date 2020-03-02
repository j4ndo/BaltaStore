using System;
using System.Linq;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order: Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem (OrderItem item) 
        { 
            _items.Add(item);
        }
        

        // Criar um Pedido
        public void Place() {
            // Gerar o número do Pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8);
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens.");            
        }        
        // Pagar um Pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;            
        }

        // Enviar um Pedido
        public void Ship()
        {
            // A cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));        
                } 
                count++;  
            }
            // Envia Todas as Entregas
            deliveries.ForEach(x => x.Ship());
            
            // Adiciona Entregas ao Pedido
            deliveries.ForEach(x => _deliveries.Add(x));
            
        }

        // Cancelar um Pedido
        public void Cancel()
        {
            Status = EOrderStatus.Cancelled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}