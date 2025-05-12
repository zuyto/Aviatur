// <copyright file="UnitOfWorkReservaVuelosDb.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using ReservaVuelos.Application.Common.Interfaces.Repository;
using ReservaVuelos.Application.Common.Interfaces.Repository.ReservaVuelosDb;
using ReservaVuelos.Application.Common.Interfaces.Services.Serilog;
using ReservaVuelos.Infrastructure.Context;
using ReservaVuelos.Infrastructure.Repositories.ReservaVuelosDb;

namespace ReservaVuelos.Infrastructure.Repositories
{
	[ExcludeFromCodeCoverage]
	public class UnitOfWorkReservaVuelosDb : IUnitOfWorkReservaVuelosDb
	{
		private readonly ISerilogImplements _serilogImplements;
		private readonly ReservaVuelosDbContext _reservaVuelosDbContext;

		public UnitOfWorkReservaVuelosDb(ReservaVuelosDbContext reservaVuelosDbContext, ISerilogImplements serilogImplements)
		{
			_serilogImplements = serilogImplements;
			_reservaVuelosDbContext = reservaVuelosDbContext;
		}

		public IReservaVuelosDbRepository ReservaVuelosDbRepository => new ReservaVuelosDbRepository(_reservaVuelosDbContext, _serilogImplements);

		public void SaveChanges()
		{
			_reservaVuelosDbContext.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _reservaVuelosDbContext.SaveChangesAsync();
		}
	}
}
