using ShiftsLogger.ConsoleApp.Views;

namespace ShiftsLogger.ConsoleApp;

/// <summary>
/// Main insertion point for the console application.
/// Configures the required application settings and launches the main menu view.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
		try
		{
			// TODO.
            var mainMenuPage = new MainMenuPage();
            mainMenuPage.Show();
		}
		catch (Exception exception)
		{
            MessagePage.Show("Error", exception);
		}
		finally
		{
			Environment.Exit(0);
		}
    }
}
