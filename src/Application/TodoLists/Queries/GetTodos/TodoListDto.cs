using azure_native_3tier_app.Domain.Entities;

namespace azure_native_3tier_app.Application.TodoLists.Queries.GetTodos;

public class TodoListDto
{
    public TodoListDto()
    {
        Items = Array.Empty<TodoItemDto>();
    }

    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Colour { get; init; }

    public IReadOnlyCollection<TodoItemDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, TodoListDto>();
        }
    }
}
