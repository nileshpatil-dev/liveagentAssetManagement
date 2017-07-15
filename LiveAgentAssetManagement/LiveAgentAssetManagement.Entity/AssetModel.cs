using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LiveAgentAssetManagement.Entity
{
    public class AssetModel
    {
        public AssetModel()
        {
            DepartmentList = new List<SelectListItem>();
            CategoryList = new List<SelectListItem>();
            BrandList = new List<SelectListItem>();
        }

        [Display(Name = "Id")]
        public int AssetId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name should not be empty.")]
        public string AssetName { get; set; }

        [Display(Name = "Sr No")]
        [Required(ErrorMessage = "Serial number should not be empty.")]
        public string AssetSrNo { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }


        [Display(Name = "Department")]
        public string DepartmentName { get; set; }
        
        public List<SelectListItem> DepartmentList { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public List<SelectListItem> CategoryList { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        public List<SelectListItem> BrandList { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "Supplier should not be empty.")]
        public string Supplier { get; set; }

        [Display(Name = "Purchased Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchasedDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResultList = new List<ValidationResult>();
            if (PurchasedDate >= Convert.ToDateTime("01/01/2000") && PurchasedDate <= DateTime.Now)
                return validationResultList;
            var validationResult = new ValidationResult("Invalid Purchase Date.");
            validationResultList.Add(validationResult);
            return validationResultList;
        }
    }

    public class AssetPageLoadData
    {
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> BrandList { get; set; }
    }
}
