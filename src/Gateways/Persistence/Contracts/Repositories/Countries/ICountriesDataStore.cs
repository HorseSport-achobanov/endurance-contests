﻿using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Countries
{
    public interface ICountriesDataStore : IDataStore
    {
        DbSet<CountryEntity> Countries { get; }
    }
}
