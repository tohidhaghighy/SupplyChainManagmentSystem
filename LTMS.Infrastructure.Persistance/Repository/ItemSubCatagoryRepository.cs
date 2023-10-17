using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class ItemSubCatagoryRepository : EFRepositoryBase<SchmDbContext, ItemSubCatagory>, IItemSubCatagoryRepository
    {
        public ItemSubCatagoryRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
