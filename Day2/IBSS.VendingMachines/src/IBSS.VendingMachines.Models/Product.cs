using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBSS.VendingMachines.Models {
		public class Product : IValidatableObject {
				public int Id { get; set; }

				[Required, StringLength(100)]
				public string Name { get; set; }

				[Range(0, 999)]
				public decimal Price { get; set; }

				[StringLength(1024)]
				public string PictureUrl { get; set; }

				[Timestamp]
				public byte[] Timestamp { get; set; }

				IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext) {
						if (Name.ToLower() == "product") {
								yield return new ValidationResult("Product cannot be named as 'Product'.", new string[] { "Name" });
						}
						if (Price % 2 == 1) {
								yield return new ValidationResult("Price cannot be an odd value.", new string[] { "Price" });
						}
				}
		}
}
