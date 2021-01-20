﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBankWebServices
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int StatusId { get { return (int)Status; } }

    }
}
