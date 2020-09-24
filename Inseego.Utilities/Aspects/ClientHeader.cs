namespace Inseego.Utilities.Aspects
{
    public static class ClientHeader
    {
        public static string UsersAcceptHeader { get; set; }
        public static string UsersContentHeader { get; set; }
        public static string TenantConfigAcceptHeader { get; set; }
        public static string TenantConfigContentHeader { get; set; }
        public static string UserConfigContentHeader { get; set; }
        public static string DeviceAcceptHeader { get; set; }
        public static string DeviceContentHeader { get; set; }
        public static string ManageVehicleAccepttHeader { get; set; }
        public static string ManageVehicleContenttHeader { get; set; }
        public static string AuthAcceptHeader { get; set; }
        public static string AuthContentHeader { get; set; }
        static ClientHeader()
        {
            UsersAcceptHeader = "application/vnd.com.inseego.platform.user.v1+json";
            UsersContentHeader = "application/vnd.com.inseego.platform.user.v1+json";
            TenantConfigAcceptHeader = "application/vnd.com.inseego.platform.tenantconfig.v1+json";
            TenantConfigContentHeader = "application/vnd.com.inseego.platform.tenantconfig.v1+json";
            UserConfigContentHeader = "application/vnd.com.inseego.platform.userconfig.v1+json";
            DeviceAcceptHeader = "application/vnd.com.inseego.platform.device.v1+json";
            DeviceContentHeader = "application/vnd.com.inseego.platform.device.v1+json";
            ManageVehicleAccepttHeader = "application/vnd.com.inseego.platform.managevehicle.v1+json";
            ManageVehicleContenttHeader = "application/vnd.com.inseego.platform.managevehicle.v1+json";
            AuthAcceptHeader = "application/vnd.com.inseego.platform.Auth.v1+json";
            AuthContentHeader = "application/vnd.com.inseego.platform.Auth.v1+json";
        }
    }
}
