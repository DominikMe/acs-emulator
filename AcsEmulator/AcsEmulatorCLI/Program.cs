using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;

class Program
{
	static async Task<int> Main(string[] args)
	{
		RootCommand rootCommand = new("Emulator for Azure Communication Services");

		Command run = new("run", description: "Run the emulator.");
		Command openApi = new("openApi", description: "Open the emulator's API in Swagger UI.");
		Command openDB = new("openDB", description: "Open the emulator's sqlite database.");
		Command openExplorer = new("openExplorer", description: "Open the emulator data explorer.");
		Command clean = new("clean", description: "Clean all data and reset the emulator state.");
		Command connectionString = new("connectionString", description: "Get the ACS connection string for the emulator.");
		Command installCert = new("installCert", description: "Install root cert to reroute real-time channel.");
		Command uninstallCert = new("uninstallCert", description: "Uninstall root cert.");

		run.SetHandler(RunEmulator);
		openApi.SetHandler(OpenSwaggerUI);
		openDB.SetHandler(OpenDB);

		rootCommand.AddCommand(run);
		rootCommand.AddCommand(openApi);
		rootCommand.AddCommand(openDB);
		rootCommand.AddCommand(openExplorer);
		rootCommand.AddCommand(clean);
		rootCommand.AddCommand(connectionString);
		rootCommand.AddCommand(installCert);
		rootCommand.AddCommand(uninstallCert);

		return await rootCommand.InvokeAsync(args);
	}

	private static void RunEmulator()
	{
		using Process proc = new();
		proc.StartInfo.WorkingDirectory = AppContext.BaseDirectory;
		proc.StartInfo.FileName = "dotnet";
		proc.StartInfo.Arguments = "--additional-deps AcsEmulatorCLI.deps.json AcsEmulatorAPI.dll";
		proc.StartInfo.UseShellExecute = true;
		proc.Start();
	}

	private static void OpenSwaggerUI() => Process.Start(new ProcessStartInfo("http://localhost:5000/swagger") { UseShellExecute = true });
	private static void OpenDB()
	{
		try
		{
			Process.Start(new ProcessStartInfo("AcsEmulator.db") { UseShellExecute = true, WorkingDirectory = AppContext.BaseDirectory });
		}
		catch (Exception ex)
		{
			if (ex.Message.Contains("cannot find the file"))
				Console.WriteLine("Please first run 'acs-emulator run' to create the database.");
			else
				Console.WriteLine(ex.Message);
		}
	}
}
