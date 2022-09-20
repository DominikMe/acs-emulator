# acs-emulator
Local emulator to run Azure Communication Services client SDKs without a provisioned ACS resource

## Getting started

* Install `dotnet ef` tool. Install by doing `dotnet tool install --global dotnet-ef` [Link for details](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

* Run `dotnet ef database update` to update your local copy of the `AcsEmulator.db` in case new migrations were added.