using CoreBankWebServices.BanCoreCommunication;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Transactions;
using System.Web.Services;
using Transaction = CoreBankWebServices.BanCoreCommunication.Transaction;

namespace CoreBankWebServices
{
    /// <summary>
    /// Summary description for CoreWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class CoreWebService : System.Web.Services.WebService
    {
        public readonly BanCoreCommunication.CoreWSSoapClient connectionToCore = new BanCoreCommunication.CoreWSSoapClient();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region Account

        [WebMethod]
        public string InsertAccount(Account acc)
        {
            string resultado = connectionToCore.InsertAccount(acc);

            if (resultado == "Cuenta Creada")
            {
                TransactionScope currentTransaction = null;
                try
                {
                    //using (currentTransaction = new TransactionScope()) 
                    //{
                    WebServiceProyectoFinalBdEntities bd = new WebServiceProyectoFinalBdEntities();
                    ObjectParameter newId = new ObjectParameter("NewId", typeof(int));
                    bd.InsertOrUpdateAccount(acc.Id, acc.Alias, acc.Number, acc.OwnerId, (int?)acc.AccountType, acc.AccountManagerId, (int?)acc.CurrencyType, (int?)acc.Status, acc.Balance, newId);
                    // currentTransaction.Complete();            
                    //}
                    return resultado;
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            else
            {
                return resultado;
            }
        }

        [WebMethod]
        public string UpdateAccount(BanCoreCommunication.Account acc)
        {
            string resultado = connectionToCore.UpdateAccount(acc);

            if (resultado == "Cuenta Modificada")
            {
                using (TransactionScope trans = new TransactionScope())
                {

                }
                //CONN BD
                return resultado;
            }
            else
            {
                return resultado;
            }
        }

        [WebMethod]
        public string DeleteAccount(int id)
        {
            string resultado = connectionToCore.DeleteAccount(id);
            if (resultado == "Cuenta elminada.")
            {
                using (TransactionScope trans = new TransactionScope())
                {

                }
                //CONN BD
                return resultado;
            }
            else
            {
                return resultado;
            }
        }

        [WebMethod]
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = (List<Account>)connectionToCore.GetAllAccounts();
            //var rows = db.getaccounts2(null, null, null, null).ToList();
            //foreach (var r in accounts)
            //{
            //  accounts.Add(new Account
            //{
            //  AccountManagerId = (int)r.AccountManagerId,
            //AccountType = (AccountType)r.AccountType,
            //Alias = r.Alias,
            //Balance = (float)r.Balance,
            //CreationDate = (DateTime)r.CreationDate,
            //CurrencyType = (CurrencyType)r.CurrencyType,
            //Id = (int)r.Id,
            //LastTransaction = (DateTime?)r.LastTransaction,
            //LastUpdate = (DateTime?)r.LastUpdate,
            //Number = r.Number,
            //OwnerId = (int)r.OwnerId,
            //Status = (Status)r.Status,
            //YesterdayBalance = (float?)r.YesterdayBalance
            //});
            //}
            //Account[] myArray = new Account[accounts.Count];
            //int i = 0;
            //foreach (Account myClass in accounts)
            //{
            //    myArray[i++] = myClass;
            //}
            //return myArray;

            //Account[] a = accounts.ToArray();
            return accounts;

        }

        [WebMethod]
        public Account GetAccountById(int id)
        {
            Account getAccById = connectionToCore.GetAccountById(id);
            return getAccById;
        }

        [WebMethod]
        public Account GetByNumber(string number)
        {
            Account getAccByNumber = connectionToCore.GetAccountByNumber(number);
            return getAccByNumber;
        }

        [WebMethod]
        public List<Account> GetAccountByClient(int clientId)
        {
            List<Account> accounts = connectionToCore.GetAccountByClient(clientId);
            //var rows = db.getaccounts2(null, null, clientId, null).ToList();
            //accounts = (List<Account>) connectionToCore.GetClientById(clientId);
            /*foreach (var r in accounts aqui va rows)
            {
                accounts.Add(new Account
                {
                    AccountManagerId = (int)r.AccountManagerId,
                    AccountType = (AccountType)r.AccountType,
                    Alias = r.Alias,
                    Balance = (float)r.Balance,
                    CreationDate = (DateTime)r.CreationDate,
                    CurrencyType = (CurrencyType)r.CurrencyType,
                    Id = (int)r.Id,
                    LastTransaction = (DateTime?)r.LastTransaction,
                    LastUpdate = (DateTime?)r.LastUpdate,
                    Number = r.Number,
                    OwnerId = (int)r.OwnerId,
                    Status = (Status)r.Status,
                    YesterdayBalance = (float?)r.YesterdayBalance
                });
            }*/
            return accounts;
        }

        [WebMethod]
        public List<Account> GetAccountByCurrencyType(int currencyTypeId)
        {
            List<Account> accounts = connectionToCore.GetAccountsByCurrencyType(currencyTypeId);
            //var rows = db.getaccounts2(null, null, null, currencyTypeId).ToList();
            /*foreach (var r in accounts)
            {
                accounts.Add(new Account
                {
                    AccountManagerId = (int)r.AccountManagerId,
                    AccountType = (AccountType)r.AccountType,
                    Alias = r.Alias,
                    Balance = (float)r.Balance,
                    CreationDate = (DateTime)r.CreationDate,
                    CurrencyType = (CurrencyType)r.CurrencyType,
                    Id = (int)r.Id,
                    LastTransaction = (DateTime?)r.LastTransaction,
                    LastUpdate = (DateTime?)r.LastUpdate,
                    Number = r.Number,
                    OwnerId = (int)r.OwnerId,
                    Status = (Status)r.Status,
                    YesterdayBalance = (float?)r.YesterdayBalance
                });
            }*/
            return accounts;
        }

        #endregion


        #region Transactions

        [WebMethod]
        public string InsertTransaction(BanCoreCommunication.Transaction transaction)
        {
            string resultado = connectionToCore.InsertTransaction(transaction);

            if (resultado == "Transaccion exitosa")
            {
                using (TransactionScope trans = new TransactionScope())
                {

                }

                //db

                return resultado;
            }
            else
            {
                return resultado;
            }
        }

        [WebMethod]
        public string UpdateTransaction(BanCoreCommunication.Transaction transaction)
        {
            string resultado = connectionToCore.UpdateTransaction(transaction);

            if (resultado == "Transaccion Modificada")
            {
                using (TransactionScope trans = new TransactionScope())
                {

                }

                //db

                return resultado;
            }
            else
            {
                return resultado;
            };
        }

        [WebMethod]
        public string DeleteTransaction(int id)
        {
            string resultado = connectionToCore.DeleteTransaction(id);
            if (resultado == "Tarjeta Desactivada.")
            {
                CoreWebService cs = new CoreWebService();
                var transaction = connectionToCore.GetTransactionById(id);
                transaction.Status = BanCoreCommunication.Status.Inactive;
                cs.UpdateTransaction(transaction);
                using (TransactionScope trans = new TransactionScope())
                {

                }

                //db

                return resultado;
            }
            else
            {
                return resultado;
            }
        }

        [WebMethod]
        public List<Transaction> GetAllTransactions()
        {

            //tenia el celular boca abajo y no sonaba, dale de nuevo
            List<Transaction> transactions = connectionToCore.GetAllTransactions();
            //var rows = db.gettransactions2(null, null, null, null, null, null, null, null, null, null, null, null, null, null).ToList();
            /*if (rows.Any())
            {
                transactions = new List<Transaction>();
                foreach (var r in transactions aqui va rows)
                {
                    transactions.Add(new Transaction
                    {
                        PayeeBankId = (int)r.PayeeBankId,
                        Concept = r.Concept,
                        CreationDate = (DateTime)r.CreationDate,
                        CurrencyType = (CurrencyType)r.CurrencyTypeId,
                        Amount = (float)r.Amount,
                        EffectiveDate = (DateTime?)r.EffectiveDate,
                        Id = (int)r.Id,
                        Number = r.Number,
                        PayeeProductNumber = r.PayeeProductNumber,
                        PayeeProductType = (ProductType)r.PayeeProductTypeId,
                        PayeeId = (int)r.PayeeId,
                        PayeeIdentification = r.PayeeIdentification,
                        PayerAccount = r.PayerAccount,
                        PayerId = (int)r.PayerId,
                        PayerIdentification = r.PayerIdentification,
                        ReferenceNumber = r.ReferenceNumber,
                        Status = (Status)r.StatusId,
                        TransactionType = (TransactionTypeEnum)r.TransactionTypeId,
                        PayerBalance = (float?)r.PayerBalance,
                        PayeeBalance = (float?)r.PayeeBalance
                    });
                }
            }*/
            return transactions;
        }

        [WebMethod]
        public Transaction GetTransactionById(int id)
        {
            Transaction transactions = connectionToCore.GetTransactionById(id);
            return transactions;
        }

        [WebMethod]
        public List<Transaction> GetTransactionByPayer(int payerId)
        {
            List<Transaction> transactions = connectionToCore.GetTransactionByPayer(payerId);

            return transactions;
        }

        [WebMethod]
        public List<Transaction> GetTransactionByPayeeId(int PayeeId)
        {
            List<Transaction> transactions = connectionToCore.GetTransactionByPayee(PayeeId);

            return transactions;
        }

        [WebMethod]
        public Transaction GetTransactionByNumber(string number)
        {
            Transaction transactions = connectionToCore.GetTransactionByNumber(number);

            return transactions;
        }

        [WebMethod]
        public Transaction GetByReference(string reference)
        {
            Transaction transactions = connectionToCore.GetTransactionByReference(reference);

            return transactions;
        }

        [WebMethod]
        public List<Transaction> FilterBy(int? payerId, string payerAccount = null, string payerIdentication = null,
            int? payeeId = null, int? payeeProductTypeId = null, string payeeProductNumber = null, string payeeIdentification = null, DateTime? creationDateFrom = null,
            DateTime? creationDateTo = null, DateTime? effectiveDateFrom = null, DateTime? effectiveDateTo = null)
        {
            List<Transaction> transactions = connectionToCore.FilterTransaction(payerId, payerAccount, payerIdentication, payeeId, payeeProductTypeId,
                payeeProductNumber, payeeIdentification, creationDateFrom, creationDateTo, effectiveDateFrom, effectiveDateTo);

            /*var rows = db.gettransactions2(null, payerId, payerAccount, payerIdentication, payeeId, payeeProductTypeId, payeeProductNumber, payeeIdentification,
                null, null, creationDateFrom, creationDateTo, effectiveDateFrom, effectiveDateTo).ToList();*/
            /*if (rows.Any())
            {
                transactions = new List<Transaction>();
                /oreach (var r in rows)
                {
                    transactions.Add(new Transaction
                    {
                        PayeeBankId = (int)r.PayeeBankId,
                        Concept = r.Concept,
                        CreationDate = (DateTime)r.CreationDate,
                        CurrencyType = (CurrencyType)r.CurrencyTypeId,
                        Amount = (float)r.Amount,
                        EffectiveDate = (DateTime?)r.EffectiveDate,
                        Id = (int)r.Id,
                        Number = r.Number,
                        PayeeProductNumber = r.PayeeProductNumber,
                        PayeeProductType = (ProductType)r.PayeeProductTypeId,
                        PayeeId = (int)r.PayeeId,
                        PayeeIdentification = r.PayeeIdentification,
                        PayerAccount = r.PayerAccount,
                        PayerId = (int)r.PayerId,
                        PayerIdentification = r.PayerIdentification,
                        ReferenceNumber = r.ReferenceNumber,
                        Status = (Status)r.StatusId,
                        TransactionType = (TransactionTypeEnum)r.TransactionTypeId,
                        PayerBalance = (float?)r.PayerBalance,
                        PayeeBalance = (float?)r.PayeeBalance
                    });
                }*/
            return transactions;
        }


        #endregion

        #region Card

        [WebMethod]
        public string InsertCard(Card card)
        {
            string cards = connectionToCore.InsertCard(card);

            if (cards == "Tarjeta Creada")
            {
                return cards;
            }
            else
            {
                return cards;
            }
        }

        [WebMethod]
        public string UpdatetCard(Card card)
        {
            string cards = connectionToCore.UpdateCard(card);

            if (cards == "Tarjeta Modificada")
            {
                return cards;
            }
            else
            {
                return cards;
            }
        }

        [WebMethod]
        public string DeleteCard(int id)
        {
            string cards = connectionToCore.DeleteCard(id);

            if (cards == "Tarjeta Desactivada")
            {
                return cards;
            }
            else
            {
                return cards;
            }
        }

        [WebMethod]
        public List<Card> GetAllCards()
        {
            List<Card> cards = connectionToCore.GetAllCards();

            return cards;
        }

        [WebMethod]
        public Card GetCardById(int id)
        {
            Card cards = connectionToCore.GetCardById(id);

            return cards;
        }

        [WebMethod]
        public List<Card> GetCardByClient(int clientId)
        {
            List<Card> cards = connectionToCore.GetCardByClient(clientId);

            return cards;
        }

        [WebMethod]
        public Card GetCardByNumber(string number)
        {
            Card cards = connectionToCore.GetCardByNumber(number);

            return cards;
        }

        #endregion

        #region Client

        [WebMethod]
        public string InsertClient(Client client)
        {
            string clients = connectionToCore.InsertClient(client);

            if (clients == "Cliente Creado")
            {
                //db

                return clients;
            }
            else
            {
                return clients;
            }
        }

        [WebMethod]
        public string UpdateClient(Client client)
        {
            string clients = connectionToCore.UpdateClient(client);

            if (clients == "Cliente Modificado")
            {
                //db

                return clients;
            }
            else
            {
                return clients;
            }
        }

        [WebMethod]
        public string DeleteClient(int id)
        {
            string clients = connectionToCore.DeleteClient(id);
            if (clients == "Cliente desativado.")
            {
                //db

                return clients;
            }
            else
            {
                return clients;
            }
        }

        [WebMethod]
        public List<Client> GetAllClients()
        {
            List<Client> clients = connectionToCore.GetAllClients();

            return clients;
        }

        [WebMethod]
        public Client GetClientById(int clientId)
        {
            Client clients = connectionToCore.GetClientById(clientId);

            return clients;
        }

        [WebMethod]
        public Client GetByIdentification(string identification)
        {
            Client clients = connectionToCore.GetClientByIdentification(identification);

            return clients;
        }
        #endregion

        #region Employee

        [WebMethod]
        public string InsertEmployeeUser(EmployeeUser user)
        {
            string employees = connectionToCore.InsertEmployeeUser(user);

            if (employees == "Usuario Creado")
            {
                //db

                return employees;
            }
            else
            {
                return employees;
            }
        }

        [WebMethod]
        public string UpdateEmployeeUser(EmployeeUser user)
        {
            string employees = connectionToCore.UpdateEmployeeUser(user);

            if (employees == "Usuario Modificado")
            {
                //db

                return employees;
            }
            else
            {
                return employees;
            }
        }

        [WebMethod]
        public EmployeeUser ValidateCredentials(string userName, string password)
        {
            EmployeeUser employeeUser = connectionToCore.ValidateEmployeeUserCredentials(userName, password);

            if (employeeUser == null)
            {
                return employeeUser;
            }
            else
            {
                return employeeUser;
            }
        }

        [WebMethod]
        public string DeleteEmployeeUser(int id)
        {
            string employee = connectionToCore.DeleteEmployeeUser(id);

            if (employee == "usuario desactivado.")
            {
                CoreWebService cs = new CoreWebService();
                var usuario = cs.GetEmployeeUserById(id);
                usuario.Status = BanCoreCommunication.Status.Inactive;
                UpdateEmployeeUser(usuario);

                //db

                return employee;
            }
            else
            {
                return employee;
            }
        }

        [WebMethod]
        public List<EmployeeUser> GetAllEmployeesUsers()
        {
            List<EmployeeUser> employeeUsers = connectionToCore.GetAllEmployeeUsers();

            return employeeUsers;
        }

        [WebMethod]
        public EmployeeUser GetEmployeeUserById(int id)
        {
            EmployeeUser employeeUser = connectionToCore.GetEmployeeUserById(id);

            return employeeUser;
        }

        [WebMethod]
        public EmployeeUser GetEmployeeUserByEmployeeId(int employeeId)
        {
            EmployeeUser employeeUser = connectionToCore.GetEmployeeUserByEmployeeId(employeeId);

            return employeeUser;
        }

        [WebMethod]
        public EmployeeUser GetByUserName(string userName)
        {
            EmployeeUser employeeUser = connectionToCore.GetEmployeeUserByUserName(userName);

            return employeeUser;
        }

        [WebMethod]
        public EmployeeUser GetEmployeeUserByEmail(string email)
        {
            EmployeeUser employeeUser = connectionToCore.GetEmployeeUserByEmail(email);

            return employeeUser;
        }

        [WebMethod]
        public List<EmployeeUser> GetEmployeeUserByEmployeeRole(int roleId)
        {
            List<EmployeeUser> employeeUserList = connectionToCore.GetEmployeeUserByRole(roleId);

            return employeeUserList;
        }

        #endregion

        #region General

        #region Bank

        [WebMethod]
        public List<Bank> GetAllBanks()
        {
            List<Bank> banks = connectionToCore.GetAllBanks();

            return banks;
        }

        [WebMethod]
        public Bank GetBankById(int id)
        {
            Bank bank = connectionToCore.GetBankById(id);

            return bank;
        }

        #endregion

        #region TransactionalTypes

        [WebMethod]
        public string InsertTransactionType(TransactionType type)
        {
            string transactionType = connectionToCore.InsertTransactionType(type);
            if (transactionType == "Tipo de Transaccio Creado")
            {
                //db

                return transactionType;
            }
            else
            {
                return transactionType;
            }
        }

        [WebMethod]
        public string UpdateTransactionType(TransactionType type)
        {
            string transactionType = connectionToCore.UpdateTransactionType(type);

            if (transactionType == "Tipo de Transaccion Modificado")
            {
                //db

                return transactionType;
            }
            else
            {
                return transactionType;
            }
        }

        /*public string DeleteTransactionType(int id)
        {
            //pending, no tiene el [WebMethod] del lado del core, una vez se haga, hay que hacer update a la referencia de la conexion del WebService del Core
            //TransactionType transactionType = conn
        }*/

        [WebMethod]
        public List<TransactionType> GetAllTransactionTypes()
        {
            List<TransactionType> transactionTypes = connectionToCore.GetAllTransactionTypes();

            return transactionTypes;
        }

        [WebMethod]
        public TransactionType GetTransactionTypeById(int id)
        {
            TransactionType transactionType = connectionToCore.GetTransactionTypeById(id);

            return transactionType;
        }

        [WebMethod]
        public TransactionType GetTransactionTypeByName(string name)
        {
            TransactionType transactionType = connectionToCore.GetTransactionTypeByName(name);

            return transactionType;
        }

        #endregion

        #endregion

        #region clientUser

        [WebMethod]
        public string InsertClientUser(User user)
        {
            string varUser = connectionToCore.InsertUser(user);

            if (varUser == "Usuario Creado")
            {
                //db

                return varUser;
            }
            else
            {
                return varUser;
            }
        }

        [WebMethod]
        public string UpdateClientUser(User user)
        {
            string varUser = connectionToCore.UpdateUser(user);

            if (varUser == "Usuario Modificado")
            {
                //db

                return varUser;
            }
            else
            {
                return varUser;
            }
        }

        [WebMethod]
        public User ValidateUserCredentials(String userName, string password)
        {
            User varUser = connectionToCore.ValidateUserCredentials(userName, password);

            if (varUser == null)
            {
                return varUser;
            }
            else
            {
                return varUser;
            }
        }

        [WebMethod]
        public string DeleteClientUser(int id)
        {
            string stringUser = connectionToCore.DeleteUser(id);
            CoreWebService cs = new CoreWebService();


            if (stringUser == "usuario desactivado.")
            {
                User varUser = cs.GetClientUserById(id);
                varUser.Status = BanCoreCommunication.Status.Inactive;
                cs.UpdateClientUser(varUser);
                return stringUser;
            }
            else
            {
                return stringUser;
            }
        }

        [WebMethod]
        public List<User> GetAllClientUsers()
        {
            List<User> users = connectionToCore.GetAllUsers();

            return users;
        }

        [WebMethod]
        public User GetClientUserById(int id)
        {
            User varUser = connectionToCore.GetUserById(id);

            return varUser;
        }

        [WebMethod]
        public User GetClientUserByUserName(string userName)
        {
            User varUser = connectionToCore.GetUserByUserName(userName);

            return varUser;
        }

        [WebMethod]
        public User GetUserClientByEmail(string email)
        {
            User varUser = connectionToCore.GetUserByEmail(email);

            return varUser;
        }
        #endregion
    }
}
