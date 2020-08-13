﻿using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TemplateMicroservice.Api.Application.Commands;
using TemplateMicroservice.Api.Application.Model;
using TemplateMicroservice.Api.Application.Validators;
using TemplateMicroservice.Domain.Aggregates.SampleAggregate;
using TemplateMicroservice.Domain.Providers;

namespace TemplateMicroservice.Api.Application.Handlers
{
    public class SampleCommandHandler : ICommandHandler<SampleCommand>
    {
        private readonly IProvider<SampleDomainEntity> _domainEntityProvider;
        private readonly ILogger<SampleCommandHandler> _logger;

        public SampleCommandHandler(IProvider<SampleDomainEntity> domainEntityProvider, ILogger<SampleCommandHandler> logger)
        {
            _domainEntityProvider = domainEntityProvider;
            _logger = logger;
        }

        public async Task<bool> Handle(SampleCommand command)
        {
            try
            {
                // Validate the command.
                var validator = new SampleCommandValidator();
                await validator.ValidateAndThrowAsync(command);

                // Convert the command to a domain entity instance.
                var domainEntity = command.ToDomainEntity();

                // Call a provider to do something useful!
                var result = _domainEntityProvider.Send(domainEntity);

                return true;
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, "An invalid command was passed to the sample handler.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An unhandled exception was caught in SampleCommandHandler.");
            }

            return false;
        }
    }
}