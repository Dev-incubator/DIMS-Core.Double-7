using System.Collections.Generic;
using System.Linq;
using DIMS_Core.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DIMS_Core.Identity.Configs
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(GetRolesData());
        }

        private static IEnumerable<Role> GetRolesData()
        {
            return IdentityConstants.RoleNames.Roles.Select((t, i) => new Role
                                                                      {
                                                                          Id = i + 1,
                                                                          Name = t
                                                                      });
        }
    }
}