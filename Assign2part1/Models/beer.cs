namespace Assign2part1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("beer")]
    public partial class beer
    {
        public int? breweryID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int beerID { get; set; }

        [StringLength(40)]
        public string beerName { get; set; }

        [StringLength(40)]
        public string beerType { get; set; }

        [StringLength(40)]
        public string canOrBottle { get; set; }

        public virtual brewery brewery { get; set; }
    }
}
