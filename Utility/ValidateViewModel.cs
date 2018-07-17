using Sunwing.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunwing.Utility
{
	public abstract class ValidatableViewModel<TViewModel, TEntity> : EntitiyMapperViewModel<TViewModel, TEntity>, IValidatableObject
		where TEntity : class
		where TViewModel : class
	{
		/// <summary>
		/// Determines whether the mapped entity is valid.
		/// </summary>
		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var modelErrors = new List<ValidationResult>();

			// Get the model to validate
			TEntity entity = this.MapToEntity();

			// Create a validation context with the model as instance
			var modelValidationContext = new ValidationContext(entity);

			// Validate
			Validator.TryValidateObject(entity, modelValidationContext, modelErrors, validateAllProperties: true);

			return modelErrors;
		}
	}
}
