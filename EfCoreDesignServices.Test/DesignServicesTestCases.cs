using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace EfCoreDesignServices
{
    internal class DesignServicesTestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            // https://learn.microsoft.com/en-us/ef/core/cli/services#list-of-services
            yield return new object[] { typeof(IAnnotationCodeGenerator), ServiceLifetime.Singleton, false };
            yield return new object[] { typeof(ICSharpHelper), ServiceLifetime.Singleton, false };
            yield return new object[] { typeof(IPluralizer), ServiceLifetime.Singleton, false };
            yield return new object[] { typeof(IMigrationsCodeGenerator), ServiceLifetime.Singleton, false };
            yield return new object[] { typeof(IMigrationsScaffolder), ServiceLifetime.Scoped, false };
            yield return new object[] { typeof(IDatabaseModelFactory), ServiceLifetime.Scoped, false };
            yield return new object[] { typeof(IModelCodeGenerator), ServiceLifetime.Singleton, true };
            yield return new object[] { typeof(IProviderConfigurationCodeGenerator), ServiceLifetime.Singleton, false };
            yield return new object[] { typeof(IReverseEngineerScaffolder), ServiceLifetime.Scoped, false };

#if NET6_0_OR_GREATER
            yield return new object[] { typeof(IScaffoldingModelFactory), ServiceLifetime.Singleton, false };
#endif
        }
    }
}
