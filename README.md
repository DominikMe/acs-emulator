# Emulator for Azure Communication Services
Local emulator to run Azure Communication Services client SDKs without a provisioned ACS resource.

## Getting started

* Install `dotnet ef` tool. Install by doing `dotnet tool install --global dotnet-ef` [Link for details](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

* Run `dotnet ef database update` to update your local copy of the `AcsEmulator.db` in case new migrations were added.

* Build and run the `AcsEmulatorApi` project

* Use `"endpoint=https://localhost/;accessKey=pw=="` as your connection string when instantiating Azure Communication Services SDK service clients.

* Use the Identity SDK with the localhost connection string and create users and tokens as usual. Use the created token to instantiate the Chat SDK.

* When running the JavaScript SDKs with Node.JS add `NODE_TLS_REJECT_UNAUTHORIZED="0"` as an env variable


## Enable real-time notifications for Chat

The URL for establishing the real-time notification channel, is unfortunately hard-coded in the Azure SDK. To enable real-time notifications in the emulator follow these steps:

1. Add `127.0.0.1 go.trouter.skype.com` to your machine's hosts file to redirect the hard-coded URL to your localhost

1. Install the `trouter_selfSigned.pfx` in your Trusted Roots certificate store using password `mypassword`. Please uninstall the cert when no longer needed.

1. Add the following as a top property of `appsettings.json`:
```json
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
```
4. Restart all browsers to load the new root cert

5. Run the `AcsEmulatorApi` project to start the emulator

Now, the Chat SDK can establish a real-time notification channel which is backed by a websocket connection in the emulator's ASP .NET Core service.

### Limitations

* Only `messageReceived` notifications are implemented
* Typing notifications and others aren't yet implemented