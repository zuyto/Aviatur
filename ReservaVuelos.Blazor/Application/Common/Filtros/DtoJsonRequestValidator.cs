// <copyright file="DtoJsonRequestValidator.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using FluentValidation;

using ReservaVuelos.Blazor.Application.Common.Models;

namespace ReservaVuelos.Blazor.Application.Common.Filtros
{
	public class DtoJsonRequestValidator : AbstractValidator<DtoJsonRequest>
	{
		public DtoJsonRequestValidator()
		{
			RuleFor(x => x.Cliente)
				.NotEmpty().WithMessage("El cliente es obligatorio");

			RuleFor(x => x.Origen)
				.NotEmpty().WithMessage("El origen es obligatorio");

			RuleFor(x => x.Destino)
				.NotEmpty().WithMessage("El destino es obligatorio");

			RuleFor(x => x.FechaSalida)
				.NotNull().WithMessage("La fecha de salida es obligatoria")
				.Must(fecha => fecha > DateTime.Today)
				.WithMessage("La fecha debe ser posterior a hoy");
		}
	}
}
