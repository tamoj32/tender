using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands
{
    public class RemoveTenderCommand : IRequest<bool>
    {
        public RemoveTenderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
