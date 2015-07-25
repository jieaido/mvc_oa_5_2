using System.Collections;

namespace MVCOA_5.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User : IEnumerable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string userPwd { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
