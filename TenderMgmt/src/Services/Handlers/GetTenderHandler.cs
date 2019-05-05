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
    public class GetTenderHandler : IRequestHandler<GetTenderQuery, TenderDto>
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IMapper _mapper;

        public GetTenderHandler(ITenderRepository tenderRepository, IMapper mapper)
        {
            this._tenderRepository = tenderRepository;
            _mapper = mapper;
        }

        public async Task<TenderDto> Handle(GetTenderQuery request, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetAsyncById(request.Id);

            return _mapper.Map<Tender, TenderDto>(tender);
        }
    }
}
