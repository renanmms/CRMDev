using CRMDev.Web.Components.Pages;

namespace CRMDev.Web.Services
{
    public interface IContactService
    {
        public Task<Contact[]> GetContactsAsync();
        public Task PostContactAsync(Contact contact);
        public Task PutContactAsync(Guid id, Contact contact);
        public Task DeleteContactAsync(Guid id);
    }   
}