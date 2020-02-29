using System;

namespace BaltaStore.Domain.StoreContext
{
    public class Customer
    {
        // Propriedades
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }  
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        //Metodos
        public void Register(){}      

        // Eventos
        public void AoRegistrar(){}
    }
}