# Emulator for Azure Communication Services
Local emulator to run Azure Communication Services client SDKs without having to provision an Azure Communication Services resource.

## Getting started

* Install `dotnet ef` tool. Install by doing `dotnet tool install --global dotnet-ef` [Link for details](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

* Run `dotnet ef database update` to update your local copy of the `AcsEmulator.db` in case new migrations were added.

* Build and run the `AcsEmulatorApi` project

* You can use the `Try it` feature in the Swagger editor to send requests against the API

* Use `"endpoint=https://localhost/;accessKey=pw=="` as your connection string when instantiating Azure Communication Services SDK service clients.

* Use the Identity SDK with the localhost connection string and create users and tokens as usual. Use the created token to instantiate the Chat SDK.

* When running the JavaScript SDKs with Node.JS add `NODE_TLS_REJECT_UNAUTHORIZED="0"` as an env variable

* You can also use endpoint `https://localhost/` to run the Live Preview of the UI library's [Chat composite](https://azure.github.io/communication-ui-library/?path=/story/composites-chat-joinexistingchatthread--join-existing-chat-thread). First, create two users with tokens and use one of the users to create a chat thread with the other user. Then, you can open two tabs side by side and fill in the the respective user, token, thread id and endpoint for each.

* You can browse the emulator data by navigating to `acs-emulator-ui`, run `npm install` and `npm run start` and open the localhost web app url that gets printed to the console

* For inspecting the DB data directly, we recommend to install [DB Browser for SQLite](https://sqlitebrowser.org/) and use it to open the `AcsEmulator.db` file

* To reset the emulator entirely and clear its data and state, delete the `AcsEmulator.db` file


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

## Limitations

* Only `/identities` and `/chat` APIs have been implemented so far
* `/identities` API has no auth and ignores the HMAC signature of the request
* `/chat` APIs are incomplete
  * token scope `chat` is not enforced
  * read receipts not implemented
  * only `messageReceived` and typing real-time notifications are implemented so far
