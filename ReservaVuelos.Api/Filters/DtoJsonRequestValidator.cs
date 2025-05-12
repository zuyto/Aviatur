// <copyright file="DtoProductosRequestValidator.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using FluentValidation;

using ReservaVuelos.Application.Common.Models.DTOs;

namespace ReservaVuelos.Api.Filters
{
	/// <summary>
	/// 
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class DtoJsonRequestValidator : AbstractValidator<DtoJsonRequest>
	{
		/// <summary>
		/// 
		/// </summary>
		public DtoJsonRequestValidator()
		{

			RuleFor(x => x.Cliente)
			.NotEmpty().WithMessage("El campo 'Cliente' es obligatorio.")
			.MaximumLength(100).WithMessage("El campo 'Cliente' no puede tener más de 100 caracteres.");

			RuleFor(x => x.Origen)
				.NotEmpty().WithMessage("El campo 'Origen' es obligatorio.")
				.Length(3, 3).WithMessage("El campo 'Origen' debe tener exactamente 3 caracteres (código IATA).");

			RuleFor(x => x.Destino)
				.NotEmpty().WithMessage("El campo 'Destino' es obligatorio.")
				.Length(3, 3).WithMessage("El campo 'Destino' debe tener exactamente 3 caracteres (código IATA).");

			RuleFor(x => x.FechaSalida)
				.GreaterThanOrEqualTo(DateTime.Today).WithMessage("La 'FechaSalida' debe ser igual o posterior a hoy.");

		}
	}
}
