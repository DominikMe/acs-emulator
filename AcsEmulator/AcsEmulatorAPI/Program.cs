using AcsEmulatorAPI;
using AcsEmulatorAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var connectionString = builder.Configuration.GetConnectionString("EmulatorDb");
builder.Services.AddDbContext<AcsDbContext>(options => options
	.UseLazyLoadingProxies()
	.UseSqlite(connectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(o => o.TokenValidationParameters = UserToken.GetTokenValidationParameters(builder.Configuration["JwtSigningKey"]));

// todo handle acsScope claim
builder.Services.AddAuthorization();

builder.Services.AddCors(options => {
	options.AddDefaultPolicy(builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
	options.AddPolicy("websocketPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(_ => true));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("user auth", new OpenApiSecurityScheme
	{
		Scheme = "bearer",
		Type = SecuritySchemeType.Http,
		In = ParameterLocation.Header
	});
	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Id = "user auth",
					Type = ReferenceType.SecurityScheme
				}
			},
			new List<string>()
		}
	});
});

builder.Services.AddSingleton(new Trouter());
builder.Services.AddSingleton(new CallAutomationWebSockets());
builder.Services.AddSingleton(new EventPublisher(
	builder.Configuration["EventGridSimulatorSystemTopicHostname"],
	builder.Configuration["EventGridSimulatorSystemTopicCredentials"]));


// If using Jaeger, set the OpenTelemetryEndpointUrl environment variable to the Jaeger endpoint
var tracingOtlpEndpoint = builder.Configuration["OpenTelemetryEndpointUrl"];
var otel = builder.Services.AddOpenTelemetry();

// Configure OpenTelemetry Resources with the application name
otel.ConfigureResource(resource => resource
    .AddService(serviceName: builder.Environment.ApplicationName));

// Add Metrics for ASP.NET Core and our custom metrics and export to Prometheus
otel.WithMetrics(metrics => metrics
	// Metrics provider from OpenTelemetry
	.AddAspNetCoreInstrumentation()
	// Metrics provides by ASP.NET Core in .NET 8
	.AddMeter("Microsoft.AspNetCore.Hosting")
	.AddMeter("Microsoft.AspNetCore.Server.Kestrel"));

// Add Tracing for ASP.NET Core and our custom ActivitySource and export to Jaeger
otel.WithTracing(tracing =>
{
    tracing.AddAspNetCoreInstrumentation();
    tracing.AddHttpClientInstrumentation();
	tracing.AddSqlClientInstrumentation(
        options => options.SetDbStatementForText = true
		);
    if (!string.IsNullOrEmpty(tracingOtlpEndpoint))
    {
        tracing.AddOtlpExporter(otlpOptions =>
        {
            otlpOptions.Endpoint = new Uri(tracingOtlpEndpoint);
        });
    }
    else
    {
        tracing.AddConsoleExporter();
    }
});



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = services.GetRequiredService<AcsDbContext>();
	context.Database.EnsureCreated();
	// TODO: seed data if we want
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.AddIdentity();
app.AddChatEndpoints();
app.AddChatThreadEndpoints();
app.AddSms();
app.UseWebSockets();
app.MapGroup("").MapEmailsApi();

app.Services.GetService<Trouter>().AddEndpoints(app);
app.Services.GetService<CallAutomationWebSockets>().AddEndpoints(app);

app.Run();

// Allow Unit testing of ASP .NET
public partial class Program { }
