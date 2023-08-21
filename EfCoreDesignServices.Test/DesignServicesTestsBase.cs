using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EfCoreDesignServices
{
    public abstract class DesignServicesTestsBase
    {
        #region Configuration

        protected MyDbContext Context { get; private set; }

        public DesignServicesTestsBase()
        {
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            OnBuildOptions(builder);
            Context = new MyDbContext(builder.Options);
        }

        protected abstract void OnBuildOptions(DbContextOptionsBuilder<MyDbContext> builder);

        #endregion

        #region Tests

        [TestCaseSource(typeof(DesignServicesTestCases))]
        public void AccordingToDocs(Type type, ServiceLifetime lifetime, bool many = false)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEntityFrameworkDesignTimeServices();
            serviceCollection.AddDbContextDesignTimeServices(Context);
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var services = (lifetime == ServiceLifetime.Scoped) ? scope.ServiceProvider : serviceProvider;

            if (many)
            {
                Assert.That(() => services.GetServices(type), Throws.Nothing);
                Assert.That(() => services.GetServices(type), Is.Not.Empty);
            }
            else
            {
                Assert.That(() => services.GetService(type), Throws.Nothing);
                Assert.That(() => services.GetService(type), Is.Not.Null);
            }
        }

        [TestCaseSource(typeof(DesignServicesTestCases))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "I know. But thats potential a problem.")]
        public void UsingDesignTimeServicesBuilder(Type type, ServiceLifetime lifetime, bool many = false)
        {
            var reporter = new TestOperationReporter();
            var assembly = typeof(DesignServicesTestsBase).Assembly;
            var builder = new DesignTimeServicesBuilder(assembly, assembly, reporter, Array.Empty<string>());
            var serviceProvider = builder.Build(Context);

            using var scope = serviceProvider.CreateScope();
            var services = (lifetime == ServiceLifetime.Scoped) ? scope.ServiceProvider : serviceProvider;

            if (many)
            {
                Assert.That(() => services.GetServices(type), Throws.Nothing);
                Assert.That(() => services.GetServices(type), Is.Not.Empty);
            }
            else
            {
                Assert.That(() => services.GetService(type), Throws.Nothing);
                Assert.That(() => services.GetService(type), Is.Not.Null);
            }
        }

        #endregion

    }
}