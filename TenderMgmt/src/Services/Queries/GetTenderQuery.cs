using Domain.Entities;
using MediatR;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries
{
    public class GetTenderQuery : IRequest<TenderDto>
    {
        public GetTenderQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
