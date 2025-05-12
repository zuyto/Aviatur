// <copyright file="IUnitOfWorkReservaVuelosDb.cs" company="Mauro Martinez">
// 	Copyright (c) 
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using ReservaVuelos.Application.Common.Interfaces.Repository.ReservaVuelosDb;

namespace ReservaVuelos.Application.Common.Interfaces.Repository
{
	public interface IUnitOfWorkReservaVuelosDb
	{
		void SaveChanges();
		Task<int> SaveChangesAsync();

		#region[REPOSITORIES]
		public IReservaVuelosDbRepository ReservaVuelosDbRepository { get; }
		#endregion
	}
}
