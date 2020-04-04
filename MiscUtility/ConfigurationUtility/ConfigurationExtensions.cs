using Microsoft.Extensions.Configuration;
using System;

namespace MiscUtility.ConfigurationUtility
{
	public static class ConfigurationExtensions
	{
		public static T BindAndReturn<T>(
			this IConfiguration configuration, string sectionName) where T : new()
		{
			if (configuration is null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			var toReturn = new T();

			configuration.GetSection(sectionName).Bind(toReturn);

			return toReturn;
		}
	}
}
