using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public abstract class ManagerForm<T> : ApiComponent where T : IManageable, new()
    {
        [Inject]
        public IManagerService ManagerService { get; set; }

        protected MudForm _form;

        protected async Task OnRequestAction(HttpMethod method, string apiPath, T item, bool validate)
        {
            T responseItem;

            if (validate)
                responseItem = await RequestHandler<T, T>(method, apiPath, item, optionalForm: _form, requestSuccessPopup: "Action was successful");
            else
                responseItem = await RequestHandler<T, T>(method, apiPath, item, requestSuccessPopup: "Action was successful");

            if (responseItem != null)
                await RefreshManager();
        }

        protected async Task OnCancel()
        {
            await RefreshManager();
        }

        protected async Task RefreshManager()
        {
            _form.Reset();
            _form.ResetValidation();
            await ManagerService.RequestRefresh();
        }
    }
}