using azure_native_3tier_app.Application.Common.Interfaces;
using azure_native_3tier_app.Application.Common.Security;
using azure_native_3tier_app.Domain.Constants;

namespace azure_native_3tier_app.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTodoListsCommand : IRequest;

public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeTodoListsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        _context.TodoLists.RemoveRange(_context.TodoLists);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
