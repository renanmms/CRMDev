using CRMDev.API.DTO.InputModels;

namespace CRMDev.API.Entities
{
    public class Contact
    {
        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public void Update(EditContactInputModel model)
        {
            Name = model.Name;
            Email = model.Email;
        }
    }
}