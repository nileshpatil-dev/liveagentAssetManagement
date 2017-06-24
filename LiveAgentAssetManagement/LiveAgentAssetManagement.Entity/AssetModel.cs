using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveAgentAssetManagement.Entity
{
    public class AssetModel
    {
        [Display(Name = "Id")]
        public int AssetId { get; set; }

        [Required(ErrorMessage = "Asset should not be empty")]
        public string AssetName { get; set; }

        [Required(ErrorMessage = "Asset serial number not be empty")]
        public string AssetSrNo { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Invalid asset department id")]
        public int AssetDepartment { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Invalid asset category id")]
        public int AssetCategory { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Invalid asset brand id")]
        public int AssetBrand { get; set; }

        public bool AssetStatus { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Invalid asset supplier id")]
        public int AssetSupplier { get; set; }

        [Required(ErrorMessage = "Invalid asset purchased date")]
        public DateTime PurchasedDate { get; set; }
    }
}
