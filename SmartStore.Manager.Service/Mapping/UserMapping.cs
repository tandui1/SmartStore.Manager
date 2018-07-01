using SmartStore.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Repository.Mapping
{
    public partial class UserMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");
            this.HasKey(i => i.OID);

        }
    }
}
