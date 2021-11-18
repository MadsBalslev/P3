using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace server.Entities
{
    public partial class databaseContext : DbContext
    {
        protected override DbEntityValidationResult ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry.Entity is Poster)
            {
                if (entityEntry.CurrentValue.GetValue<string>("Name") == "")
                {
                    var list = new List <System.Data.Entity.Validation.DbValidationError>();
                    list.Add(new System.Data.Entity.Validation.DbValidationError("Name", "Name cannot be empty"));

                    return new System.Data.Entity.Validation.DbEntityValidationResult(entityEntry, list);
                    
                }
            }
            
            
            return base.ValidateEntity(entityEntry, items);
        }
    }
}