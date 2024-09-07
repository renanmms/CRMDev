using CRMDev.API.DTO.InputModels;
using CRMDev.API.Entities;
using CRMDev.API.Persistence;

namespace CRMDev.API.Endpoints
{
    public static class ContactEndpoints
    {
        public static WebApplication AddContactEndpoints(this WebApplication app)
        {
            app.MapGet("/api/contacts", (CRMContext context) => {
                var contacts = context.Contacts.ToList();

                return Results.Ok(contacts);
            });

            app.MapGet("/api/contacts/{id}", (Guid id, CRMContext context) => {
                var contact = context.Contacts.SingleOrDefault(c => c.Id == id);

                if(contact is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(contact);
            });

            app.MapPost("/api/contacts", (CRMContext context, CreateContactInputModel model) => {
                var contact = new Contact(model.Name, model.Email);

                context.Add(contact);
                context.SaveChanges();

                return Results.Created($"/api/contacts/{contact.Id}", contact);
            });

            app.MapPut("/api/contacts/{id}", (CRMContext context, Guid id, EditContactInputModel model) => {
                var contact =  context.Contacts.SingleOrDefault(c => c.Id == id);

                if(contact is null) 
                {
                    return Results.NotFound();
                }

                contact?.Update(model);
                context.SaveChanges();

                return Results.NoContent();
            });

            app.MapDelete("/api/contacts/{id}", (CRMContext context, Guid id) => {
                var contact = context.Contacts.SingleOrDefault(c => c.Id == id);

                if(contact is null)
                {
                    return Results.NotFound();
                }

                context.Contacts.Remove(contact);
                context.SaveChanges();

                return Results.NoContent();
            });

            return app;
        }
    }
}