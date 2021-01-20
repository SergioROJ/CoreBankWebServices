using probandoCoreWsProyectoFinal.CoreWebService;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

namespace probandoCoreWsProyectoFinal
{
    class Program
    {
        CoreWebService.CoreWebServiceSoapClient comunicando = new CoreWebService.CoreWebServiceSoapClient();
        static void Main(string[] args)
        {
            ObjectParameter newId = new ObjectParameter("NewId", typeof(int));
            Program p = new Program();

            //Console.WriteLine(String.Join<Account>(", "), p.comunicando.GetAll());

            List<Account> array = p.comunicando.GetAllAccounts();

            foreach (var item in array)
            {
                Console.WriteLine(String.Join<Account>(", ", array)); //terminar esto con los parametros individuales, hay que recogerlos 1 por 1
            }

            //p.UpdateAccount();

            Account cuenta = new Account()
            {
                Id = 55,
                Alias = "CuentaPepitoGuebito",
                OwnerId = 777,
                Number = "69898946",
                AccountType = AccountType.Other,
                AccountManagerId = 666,
                CurrencyType = CurrencyType.EUR,
                Status = Status.Active,
                Balance = 150121512
            };

            string resultado = p.comunicando.InsertAccount(cuenta);
            Console.WriteLine(resultado);
            Console.ReadKey();

        }

        public void InsertAccount()
        {
            var crearCuenta = new CoreWebService.Account
            {
                Alias = "cuenta prueba",
                Number = "123",
                OwnerId = 1,
                AccountType = CoreWebService.AccountType.Current,
                AccountManagerId = 1,
                CurrencyType = CoreWebService.CurrencyType.EUR,
                Status = Status.Active,
                Balance = 1500
            };
            string enviar = comunicando.InsertAccount(crearCuenta);

            Console.WriteLine(enviar);
            Console.ReadKey();
        }

        public void UpdateAccount()
        {
            var crearCuenta = new CoreWebService.Account
            {
                Alias = "cuenta prueba",
                Number = "123",
                OwnerId = 1,
                AccountType = CoreWebService.AccountType.Current,
                AccountManagerId = 1,
                CurrencyType = CoreWebService.CurrencyType.EUR,
                Status = Status.Active,
                Balance = 1500
            };
            string enviar = comunicando.UpdateAccount(crearCuenta);

            Console.WriteLine(enviar);
            Console.ReadKey();
        }
    }
}
