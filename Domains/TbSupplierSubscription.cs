using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public partial class TbSupplierSubscription
    {
        public Guid? SupplierSubscriptionId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم التاجر   ")]
        public Guid? SupplierId { get; set; }
       
        public string? SupplierName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل بداية  الاشتراك  ")]
        public DateTime? StartdDate { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل نهاية  الاشتراك  ")]
        public DateTime? EnddDate { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الباكاج   ")]
        public string? SubscriptionPackage { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
