using System.Diagnostics;

namespace ShiftsLogger.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
		try
		{
			// TODO.
		}
		catch (Exception exception)
		{
			Trace.TraceError(exception.Message);
		}
		finally
		{
			Environment.Exit(0);
		}
    }
}
