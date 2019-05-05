using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class TenderTagDto
    {
        public int Id { get; set; }

        public int TenderId { get; set; }

        public string TagName { get; set; }
    }
}
