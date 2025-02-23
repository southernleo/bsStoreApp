using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CatagoryId);
            builder.Property(c=>c.CatagoryName).IsRequired();
            builder.HasData(
            new Category()
            {
                CatagoryId = 1,
                CatagoryName = "Computer Science"
            },
            new Category()
            {
                CatagoryId = 2,
                CatagoryName = "Network "
            },
            new Category()
             {
                 CatagoryId = 3,
                 CatagoryName = "Database Management Systems "
             }
             );
        }
    }
}
