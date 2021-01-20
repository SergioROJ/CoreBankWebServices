//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreBankWebServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class transactions
    {
        public int Id { get; set; }
        public Nullable<int> PayerId { get; set; }
        public string PayerAccount { get; set; }
        public string PayerIdentification { get; set; }
        public int PayeeId { get; set; }
        public string PayeeAccount { get; set; }
        public string PayeeIdentification { get; set; }
        public int PayeeBankId { get; set; }
        public Nullable<int> TransactionTypeId { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string Number { get; set; }
        public string Concept { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public Nullable<int> CurrencyTypeId { get; set; }
        public Nullable<double> Balance { get; set; }
        public string ReferenceNumber { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<int> StatusId { get; set; }
    }
}