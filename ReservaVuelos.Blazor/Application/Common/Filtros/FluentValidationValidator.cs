// <copyright file="FluentValidationValidator.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;

namespace ReservaVuelos.Blazor.Application.Common.Filtros
{
	public class FluentValidationValidator<T>
	{
		private readonly IValidator<T> _validator;

		public FluentValidationValidator(IValidator<T> validator)
		{
			_validator = validator;
		}

		public bool Validate(EditContext editContext, out ValidationMessageStore messages)
		{
			var model = (T)editContext.Model;
			var context = new ValidationContext<T>(model);
			var result = _validator.Validate(context);

			messages = new ValidationMessageStore(editContext);
			messages.Clear();

			foreach (var error in result.Errors)
			{
				var field = new FieldIdentifier(model, error.PropertyName);
				messages.Add(field, error.ErrorMessage);
			}

			editContext.NotifyValidationStateChanged();
			return result.IsValid;
		}
	}
}
