using Equinox.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Domain;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Behaviour
{
    internal class UnitOfWorkBehaviour<IRequest,IResponse> : IPipelineBehavior<IRequest,IResponse> where IRequest : IRequest<IResponse> 
                                                                                                   where IResponse : ValidationResult
    {
        private IRepositoryBase<Entity> _baseRepo;

        public UnitOfWorkBehaviour(IRepositoryBase<Entity> BaseRepo) {
            _baseRepo = BaseRepo;
        }

        public async Task<IResponse> Handle(IRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<IResponse> next)
        {
            var CommandResponse = await next();

            if(CommandResponse.Errors.Any()) return CommandResponse;

            var commitResult = await _baseRepo.UnitOfWork.Commit();

            if (!commitResult)
            {
                CommandResponse.Errors.Add(new ValidationFailure(string.Empty, "There was an error saving data"));
            }

            return CommandResponse;
        }
    }
}
