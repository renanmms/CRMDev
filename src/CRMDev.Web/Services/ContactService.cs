using CRMDev.Web.Components.Pages;

namespace CRMDev.Web.Services
{
    public class ContactService : IContactService
    {
        private HttpClient _client;
        public ContactService(HttpClient client)
        {
            _client = client;
        }

        public async Task DeleteContactAsync(Guid id)
        {
            var requestUri = $"api/contacts/{id}";
            await _client.DeleteFromJsonAsync<Contact>(requestUri);
        }

        public async Task<Contact[]> GetContactsAsync()
        {
            var requestUri = "api/contacts";
            return await _client.GetFromJsonAsync<Contact[]>(requestUri);
        }

        public async Task PostContactAsync(Contact contact)
        {
            var requestUri = "api/contacts";
            await _client.PostAsJsonAsync<Contact>(requestUri, contact);
        }

        public async Task PutContactAsync(Guid id, Contact contact)
        {
            var requestUri = $"api/contacts/{id}";
            await _client.PutAsJsonAsync<Contact>(requestUri, contact);
        }
    }
}