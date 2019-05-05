using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TenderTag
    {
        public int Id { get; set; }

        public int TenderId { get; set; }

        public string TagName { get; set; }
    }
}
