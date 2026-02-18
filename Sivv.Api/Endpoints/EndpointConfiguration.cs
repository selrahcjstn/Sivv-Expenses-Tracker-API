namespace Sivv.Api.Endpoints
{
    public static class EndpointConfiguration
    {
        public static void MapApiEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapUserEndpoints();
            app.MapUserProfileEndpoints();
        }
    }
}