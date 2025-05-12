// <copyright file="ApiResponse.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace ReservaVuelos.Blazor.Application.Common.Models
{
	[ExcludeFromCodeCoverage]
	public class ApiResponse<T>
	{
		/// <summary>
		///     OkMessage
		/// </summary>
		public string? OkMessage { get; set; }

		/// <summary>
		///     IsSuccessful
		/// </summary>
		public bool IsSuccessful { get; set; }

		/// <summary>
		///     ErrorMessage
		/// </summary>
		public string? ErrorMessage { get; set; }

		/// <summary>
		///     IsError
		/// </summary>
		public bool IsError { get; set; }


		/// <summary>
		///     Messages
		/// </summary>
		public IEnumerable<string>? Messages { get; set; }

		/// <summary>
		/// </summary>
		public T? Result { get; set; }

	}
}
