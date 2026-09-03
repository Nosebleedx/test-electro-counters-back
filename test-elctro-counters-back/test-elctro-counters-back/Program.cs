using test_elctro_counters_back.Services;

namespace test_elctro_counters_back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            const string frontendPolicy = "Frontend";

            builder.Services.AddScoped<CountersDataService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(frontendPolicy, policy =>
                {
                    policy
                        .WithOrigins(
                            "http://localhost:4200",
                            "http://127.0.0.1:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Для локальной разработки по HTTP оставляем выключенным.
            // app.UseHttpsRedirection();

            app.UseCors(frontendPolicy);

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}