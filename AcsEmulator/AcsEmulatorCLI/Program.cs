using System.CommandLine;
using System.Diagnostics;

class Program
{
	static async Task<int> Main(string[] args)
	{
		RootCommand rootCommand = new("Emulator for Azure Communication Services");

		Command run = new("run", description: "Run the emulator.");
		Command openApi = new("openApi", description: "Open the emulator's API in Swagger UI.");
		Command openDB = new("openDB", description: "Open the emulator's sqlite database.");
		Command openUI = new("openUI", description: "Open the emulator UI.");
		Command clean = new("clean", description: "Clean all data and reset the emulator state.");
		Command connectionString = new("connectionString", description: "Get the ACS connection string for the emulator.");
		Command installCert = new("installCert", description: "Install root cert to reroute real-time channel.");
		Command uninstallCert = new("uninstallCert", description: "Uninstall root cert.");
		Command repo = new("repo", description: "Open code repository.");

		run.SetHandler(Run);
		openApi.SetHandler(OpenSwaggerUI);
		openDB.SetHandler(OpenDB);
		openUI.SetHandler(OpenUI);
		clean.SetHandler(CleanDB);
		installCert.SetHandler(InstallCert);
		connectionString.SetHandler(GetConnectionString);
		repo.SetHandler(OpenRepo);

		rootCommand.AddCommand(run);
		rootCommand.AddCommand(openApi);
		rootCommand.AddCommand(openDB);
		rootCommand.AddCommand(openUI);
		rootCommand.AddCommand(clean);
		rootCommand.AddCommand(connectionString);
		//rootCommand.AddCommand(installCert);
		//rootCommand.AddCommand(uninstallCert);
		rootCommand.AddCommand(repo);

		return await rootCommand.InvokeAsync(args);
	}

	private static async Task Run()
	{
		_ = StartEmulator();
		await OpenUI();
	}

	private static Task StartEmulator()
	{
		using Process proc = new();
		proc.StartInfo.WorkingDirectory = AppContext.BaseDirectory;
		proc.StartInfo.FileName = "dotnet";
		proc.StartInfo.Arguments = "--additional-deps AcsEmulatorCLI.deps.json AcsEmulatorAPI.dll --urls=https://localhost/";
		proc.StartInfo.UseShellExecute = true;
		proc.Start();
		return proc.WaitForExitAsync();
	}

	private static void OpenSwaggerUI() => Process.Start(new ProcessStartInfo("https://localhost/swagger") { UseShellExecute = true });

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

	private static async Task OpenUI()
	{
		try
		{
			using Process install = new();
			install.StartInfo.WorkingDirectory = AppContext.BaseDirectory;
			install.StartInfo.FileName = "npm.cmd";
			install.StartInfo.Arguments = "install -g serve";
			install.StartInfo.UseShellExecute = false;
			install.Start();
			install.WaitForExit();

			using Process serve = new();
			serve.StartInfo.WorkingDirectory = AppContext.BaseDirectory;
			serve.StartInfo.FileName = "serve";
			serve.StartInfo.Arguments = "-s .";
			serve.StartInfo.UseShellExecute = true;
			serve.Start();

			await Task.Delay(3000);

			Process.Start(new ProcessStartInfo("http://localhost:3000") { UseShellExecute = true });
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private static void OpenRepo() => Process.Start(new ProcessStartInfo("https://github.com/DominikMe/acs-emulator") { UseShellExecute = true });

	private static void CleanDB()
	{
		var path = $"{AppContext.BaseDirectory}/AcsEmulator.db";
		if (File.Exists(path))
			File.Delete(path);
	}

	private static void GetConnectionString() => Console.WriteLine("endpoint=https://localhost/;accessKey=pw==");

	private static void InstallCert()
	{
		Console.WriteLine("""
			Add 127.0.0.1 go.trouter.skype.com to your machine's hosts file to redirect the hard-coded URL to your localhost.
			Press enter when done.
			""");
		Console.ReadLine();
		Console.WriteLine("""
			Install the trouter_selfSigned.pfx in your Trusted Roots certificate store using password 'mypassword'. Please uninstall the cert when no longer needed.
			Press enter when done.
			""");
		Process.Start(new ProcessStartInfo("trouter_selfSigned.pfx") { UseShellExecute = true, WorkingDirectory = AppContext.BaseDirectory });
		Console.ReadLine();

		// oops, how do we build and package that?
		Console.WriteLine("""
			Add the following as a top property of appsettings.json:

			"Kestrel": {
			  "Endpoints": {
			    "HttpsInlineCertFile": {
			      "Url": "https://localhost",
			      "Certificate": {
			        "Path": "trouter_selfSigned.pfx",
			        "Password": "mypassword"
			      }
			    }
			  }
			},
			""");
	}
}
