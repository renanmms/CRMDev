using CRMDev.API.DTO.InputModels;
using CRMDev.API.Entities;
using CRMDev.API.Persistence;

namespace CRMDev.API.Endpoints
{
    public static class OpportunityEndpoints
    {
        public static WebApplication AddOpportunityEndpoints(this WebApplication app) 
        {
            app.MapGet("/api/opportunities", (CRMContext context) => {
                var opportunities = context.Opportunities.ToList();

                return Results.Ok(opportunities);
            });

            app.MapGet("/api/opportunities/{id}", (Guid id, CRMContext context) => {
                var opportunity = context.Opportunities.SingleOrDefault(o => o.Id == id);

                if(opportunity is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(opportunity);
            });

            app.MapPost("/api/opportunities", (CRMContext context, CreateOpportunityInputModel model) => {
                var opportunity = new Opportunity(
                    model.Title,
                    model.Description,
                    model.DueDate,
                    model.Budget,
                    model.HasSupport,
                    model.Status,
                    model.Reason);

                context.Add(opportunity);
                context.SaveChanges();

                return Results.Created($"/api/opportunities/{opportunity.Id}", opportunity);
            });

            app.MapPut("/api/opportunities/{id}", (Guid id, CRMContext context, EditOpportunityInputModel model) => {
                var opportunity = context.Opportunities.SingleOrDefault(o => o.Id == id);

                if(opportunity is null)
                {
                    return Results.NotFound();
                }

                opportunity.Update(model);
                context.SaveChanges();

                return Results.NoContent();
            });

            return app;
        }
    }
}