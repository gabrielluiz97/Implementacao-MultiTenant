using Microsoft.EntityFrameworkCore.Diagnostics;
using Multitenant.API.Provider;
using System.Data.Common;

namespace Multitenant.API.Interceptors
{
    public class StrategySchemaInterceptor : DbCommandInterceptor
    {
        private readonly TenantData _tenant;

        public StrategySchemaInterceptor(TenantData tenant)
        {
            _tenant = tenant;
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting
            (DbCommand command,
            CommandEventData eventData, 
            InterceptionResult<DbDataReader> result)
        {
            ReplaceSchema(command);

            return base.ReaderExecuting(command, eventData, result);
        }

        private void ReplaceSchema(DbCommand command)
        {
            //FROM PRODUCTS -> FROM [tenant-1].Products
            command.CommandText = command.CommandText
                .Replace("FROM public.", $" FROM {_tenant.TenantId}.")
                .Replace("JOIN public.", $" JOIN {_tenant.TenantId}.");
        }
    }
}
