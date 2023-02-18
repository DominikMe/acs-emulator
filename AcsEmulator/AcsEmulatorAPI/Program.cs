using AcsEmulatorAPI;
using AcsEmulatorAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
	options.AddPolicy("trouterPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(_ => true));
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
builder.Services.AddSingleton(new EventPublisher(
	builder.Configuration["EventGridSimulatorSystemTopicHostname"],
    builder.Configuration["EventGridSimulatorSystemTopicCredentials"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

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

app.Run();
