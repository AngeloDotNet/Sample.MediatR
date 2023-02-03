﻿using MediatR;
using Sample.API.Entity;
using Sample.API.MediatR;
using Sample.API.Service;

namespace Sample.API.Handlers;

public class GetPersonHandler : IRequestHandler<GetPersonQuery, PersonEntity>
{
    private readonly ILogger<GetPersonHandler> logger;
    private readonly IPeopleService peopleService;

    public GetPersonHandler(ILogger<GetPersonHandler> logger, IPeopleService peopleService)
    {
        this.logger = logger;
        this.peopleService = peopleService;
    }

    public async Task<PersonEntity> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var result = await peopleService.GetPersonAsync(request.Id);

        return await Task.FromResult(result);
    }
}