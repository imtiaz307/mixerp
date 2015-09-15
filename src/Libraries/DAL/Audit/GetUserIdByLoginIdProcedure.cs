/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).
This file is part of MixERP.
MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/
//Resharper disable All
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using PetaPoco;
using MixERP.Net.Entities.Audit;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Audit.Data
{
	/// <summary>
	/// Prepares, validates, and executes the function "audit.get_user_id_by_login_id(pg_arg0 bigint)" on the database.
	/// </summary>
	public class GetUserIdByLoginIdProcedure: DbAccess
	{
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
	    public override string ObjectNamespace => "audit";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
	    public override string ObjectName => "get_user_id_by_login_id";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
		public long LoginId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string Catalog { get; set; }

		/// <summary>
		/// Maps to "pg_arg0" argument of the function "audit.get_user_id_by_login_id".
		/// </summary>
		public long PgArg0 { get; set; }

		/// <summary>
		/// Prepares, validates, and executes the function "audit.get_user_id_by_login_id(pg_arg0 bigint)" on the database.
		/// </summary>
		public GetUserIdByLoginIdProcedure()
		{
		}

		/// <summary>
		/// Prepares, validates, and executes the function "audit.get_user_id_by_login_id(pg_arg0 bigint)" on the database.
		/// </summary>
		/// <param name="pgArg0">Enter argument value for "pg_arg0" parameter of the function "audit.get_user_id_by_login_id".</param>
		public GetUserIdByLoginIdProcedure(long pgArg0)
		{
			this.PgArg0 = pgArg0;
		}
		/// <summary>
		/// Prepares and executes the function "audit.get_user_id_by_login_id".
		/// </summary>
		public int Execute()
		{
			if (!this.SkipValidation)
			{
				if (!this.Validated)
				{
					this.Validate(AccessTypeEnum.Execute, this.LoginId, false);
				}
				if (!this.HasAccess)
				{
                    Log.Information("Access to the function \"GetUserIdByLoginIdProcedure\" was denied to the user with Login ID {LoginId}.", this.LoginId);
					throw new UnauthorizedException("Access is denied.");
				}
			}
			const string query = "SELECT * FROM audit.get_user_id_by_login_id(@0::bigint);";
			return Factory.Scalar<int>(this.Catalog, query, this.PgArg0);
		} 
	}
}