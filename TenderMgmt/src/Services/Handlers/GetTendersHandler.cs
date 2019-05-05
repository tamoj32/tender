using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using MediatR;
using Services.Models;
using Services.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers
{
    public class GetTendersHandler : IRequestHandler<GetTendersQuery, IEnumerable<TenderDto>>
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IMapper _mapper;

        public GetTendersHandler(ITenderRepository tenderRepository, IMapper mapper)
        {
            this._tenderRepository = tenderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TenderDto>> Handle(GetTendersQuery request, CancellationToken cancellationToken)
        {
            var tenders = await _tenderRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Tender>, IEnumerable<TenderDto>>(tenders);
        }
    }
}
