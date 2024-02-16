using azure_native_3tier_app.Domain.Events;
using Microsoft.Extensions.Logging;

namespace azure_native_3tier_app.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("azure_native_3tier_app Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
