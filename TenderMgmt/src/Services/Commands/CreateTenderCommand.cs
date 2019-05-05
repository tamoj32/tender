using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands
{
    public class CreateTenderCommand : IRequest<int>
    {
        public CreateTenderCommand(Tender tender)
        {
            Tender = tender;
        }

        public Tender Tender { get; }
    }
}
