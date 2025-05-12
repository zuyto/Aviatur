// <copyright file="LoggerEnricher.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Security.Claims;

using ReservaVuelos.Logger.Static;

using Serilog.Core;
using Serilog.Events;

namespace ReservaVuelos.Logger.Enricher
{
	internal class LoggerEnricher : ILogEventEnricher
	{
		private readonly ClaimsPrincipal _currentUser;

		public LoggerEnricher() : this(new ClaimsPrincipal())
		{
		}

		public LoggerEnricher(ClaimsPrincipal currentUser)
		{
			_currentUser = currentUser;
		}

		public void Enrich(LogEvent logEvent,
			ILogEventPropertyFactory propertyFactory)
		{
			var identity = _currentUser.Identity;
			var property = propertyFactory.CreateProperty(ConfigTypeMessage.USUARIO,
				identity != null && identity.Name != null
					? identity.Name
					: ConfigTypeMessage.ANONYMOUS);
			logEvent.AddPropertyIfAbsent(property);
		}
	}
}
