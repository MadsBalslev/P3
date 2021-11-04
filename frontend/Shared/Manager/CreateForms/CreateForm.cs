using Microsoft.AspNetCore.Components;

public abstract class CreateForm<T> : ComponentBase
{
    [Parameter]
    public EventCallback<T> OnAddPoster { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

}