namespace Assign2part1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("brewery")]
    public partial class brewery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brewery()
        {
            beers = new HashSet<beer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int breweryID { get; set; }

        [StringLength(50)]
        public string breweryLocation { get; set; }

        [StringLength(50)]
        public string breweryName { get; set; }

        [StringLength(100)]
        public string features { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<beer> beers { get; set; }
    }
}
