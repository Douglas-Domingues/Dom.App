using Dom.Api.Endpoints;

namespace Dom.Api.Common.Api
{
    public static class AppExtension
    {
        public static void ConfigureDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }
        public static void UseSecurity(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

        }

        public static void InitiApp(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
                app.ConfigureDevEnvironment();

            app.UseCors(ApiConfiguration.CorsPolicyName);
            app.UseSecurity();
            app.MapEndpoints();
        }

    }
}
