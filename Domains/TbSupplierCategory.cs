using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public partial class TbSupplierCategory
    {
        public Guid? SupplierCategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم  قسم التاجر ")]
        public string? SupplierCategoryName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف  قسم التاجر ")]
        public string? SupplierCategoryDescription { get; set; }
      
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
