using Microsoft.AspNetCore.Components;

public abstract class EditForm<T> : ComponentBase
{
    [Parameter]
    public EventCallback<T> OnEdit { get; set; }

    [Parameter]
    public EventCallback<T> OnDelete { get; set; }

    [Parameter]
    public EventCallback<T> OnCancel { get; set; }
}