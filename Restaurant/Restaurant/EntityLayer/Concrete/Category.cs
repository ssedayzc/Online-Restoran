using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(150)]
        public string CategoryName { get; set; }
        [StringLength(150)]
        public string Image { get; set; }

        [StringLength(600)]
        public string Description { get; set; }

        [StringLength(600)]
        public string CreatedBy { get; set; }
        [StringLength(600)]
        public string CreatedOn { get; set; }

        [StringLength(600)]
        public string ModifiedBy { get; set; }
        [StringLength(600)]
        public string ModifiedOn { get; set; }
        [StringLength(600)]
        public string DeletedBy { get; set; }
        [StringLength(600)]
        public string DeletedOn { get; set; }
        public bool IsActive { get; set; }


        public ICollection<Items> Items { get; set; }
    }
}
