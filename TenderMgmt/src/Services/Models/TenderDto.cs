using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class TenderDto
    {
        public int Id { get; set; }

        public string ReferenceNumber { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime ClosingDate { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public List<TenderTagDto> TenderTags { get; set; }
    }
}
