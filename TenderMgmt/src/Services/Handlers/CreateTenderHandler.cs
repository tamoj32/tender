using Domain.IRepository;
using MediatR;
using Services.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers
{
    public class CreateTenderHandler : IRequestHandler<CreateTenderCommand, int>
    {
        private readonly ITenderRepository _tenderRepository;

        public CreateTenderHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<int> Handle(CreateTenderCommand request, CancellationToken cancellationToken)
        {
            var id = await _tenderRepository.Add(request.Tender);
            return id;
        }
    }
}
