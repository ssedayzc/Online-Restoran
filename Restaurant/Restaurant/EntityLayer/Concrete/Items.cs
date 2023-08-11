using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; } //çeşit id 

        [StringLength(500)]
        public string ItemName { get; set; } // çeşit adı 

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }
        public bool IsActive { get; set; }

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
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
