﻿using Domain.ErrorHandlers;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Queries.Identity.IsEmailUsed;

public class IsEmailUsedQueryHandler : IQueryHandler<IsEmailUsedQuery, bool>
{
    private readonly ApplicationDbContext _context;

    public IsEmailUsedQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(IsEmailUsedQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(
            u => u.NormalizedEmail == request.Email.ToUpper(), cancellationToken);
    }
}