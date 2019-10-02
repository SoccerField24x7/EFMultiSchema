using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webtest.dbcontext.Models
{

    public class Tenant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50)]
        public string TenantName { get; set; }

        [MaxLength(25)]
        public string SchemaId { get; set; }

        public byte IsActive { get; set; }
    }
}
