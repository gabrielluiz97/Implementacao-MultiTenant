namespace Multitenant.API.Provider
{
    public class TenantData
    {
        public TenantData(string tenantId = null)
        {
            TenantId = tenantId ?? TenantId;
        }

        public string TenantId { get; set; } = "public";
    }
}
