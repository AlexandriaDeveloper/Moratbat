using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Common.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }

}