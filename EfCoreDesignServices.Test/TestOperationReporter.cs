using Microsoft.EntityFrameworkCore.Design.Internal;

namespace EfCoreDesignServices
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "But.. they forced me to do this.")]
    internal class TestOperationReporter : IOperationReporter
    {
        public void WriteInformation(string message)
        {
            Console.WriteLine("info:    " + message);
        }

        public void WriteVerbose(string message)
        {
            Console.WriteLine("verbose: " + message);
        }

        public void WriteWarning(string message)
        {
            Console.WriteLine("warn:    " + message);
        }

        public void WriteError(string message)
        {
            Console.WriteLine("error:   " + message);
        }
    }
}
