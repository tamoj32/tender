using Domain.Entities;
using MediatR;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries
{
    public class GetTendersQuery : IRequest<IEnumerable<TenderDto>>
    {
    }
}
