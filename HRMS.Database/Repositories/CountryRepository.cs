﻿using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class CountryRepository(Context context, IMapper mapper) : BaseRepository<Country, Core.Models.Country, CountrySearch>(context, mapper), ICountryRepository
{
    protected override IQueryable<Country> AddInclude(IQueryable<Country> query, CountrySearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        return query;
    }
}