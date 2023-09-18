using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Ksu.Market.Api
{
	/// <summary>
	/// Конфигурация сваггера
	/// </summary>
	public static class SwaggerOptions
	{
		/// <summary>
		/// Конфигурация генерации сваггера
		/// </summary>
		/// <param name="services"></param>
		public static void Configure(IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Market Place Web API",
					Contact = new()
					{
						Email = "roma.veselov.1990+webapi@mail.ru",
						Name = "Roman Veselov",
						Url = new Uri("https://vk.com/exp3cted")
					},
					Description = "Market Place Controllers",
					Version = "v1"
				});

				//options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
				//{
				//	In = ParameterLocation.Header,
				//	Description = "Please enter a valid token",
				//	Name = "Authorization",
				//	Type = SecuritySchemeType.Http,
				//	BearerFormat = "JWT",
				//	Scheme = "Bearer"
				//});
				//options.AddSecurityRequirement(new OpenApiSecurityRequirement
				//{
				//	{
				//		new OpenApiSecurityScheme
				//		{
				//			Reference = new OpenApiReference
				//			{
				//				Type = ReferenceType.SecurityScheme,
				//				Id = "Bearer"
				//			}
				//		},
				//		Array.Empty<string>()
				//	}
				//});


				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				options.IncludeXmlComments(xmlPath);
			});
		}
	}
}
