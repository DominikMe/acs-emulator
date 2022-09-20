---
page_type: sample
languages:
  - typescript
products:
  - azure
  - azure-communication-services
urlFragment: communication-identity-typescript
---

# Azure Communication Services - Identity client library samples for TypeScript

These sample programs show how to use the TypeScript client libraries for Azure Communication Services - Identity in some common scenarios.

| **File Name**                                   | **Description**                                                                             |
| ----------------------------------------------- | ------------------------------------------------------------------------------------------- |
| [issueToken.ts][issuetoken]                     | Issue a new user token.                                                                     |
| [revokeTokens.ts][revoketokens]                 | Revoke user tokens.                                                                         |

## Prerequisites

The sample programs are compatible with [LTS versions of Node.js](https://nodejs.org/about/releases/).

Before running the samples in Node, they must be compiled to JavaScript using the TypeScript compiler. For more information on TypeScript, see the [TypeScript documentation][typescript]. Install the TypeScript compiler using:

```bash
npm install -g typescript
```

These samples run against a local emulator of Azure Communication Services, so an Azure subscription and Azure Communication Services resource is not needed.

Make sure that the emulator is running and the ports in the `.env` file are matching.

Adapting the samples to run in the browser may require some additional consideration. For details, please see the [package README][package].

## Setup

To run the samples using the published version of the package:

1. Install the dependencies using `npm`:

```bash
npm install
```

2. Compile the samples:

```bash
npm run build
```

3. Edit the file `sample.env`, adding the correct credentials to access the Azure service and run the samples. Then rename the file from `sample.env` to just `.env`. The sample programs will read this file automatically.

4. Run whichever samples you like (note that some samples may require additional setup, see the table above):

```bash
node dist/issueToken.js
```

## Next Steps

Take a look at our [API Documentation][apiref] for more information about the APIs that are available in the clients.

[gettokenforteamsuser]: https://github.com/Azure/azure-sdk-for-js/blob/main/sdk/communication/communication-identity/samples/v1/typescript/src/getTokenForTeamsUser.ts
[issuetoken]: https://github.com/Azure/azure-sdk-for-js/blob/main/sdk/communication/communication-identity/samples/v1/typescript/src/issueToken.ts
[revoketokens]: https://github.com/Azure/azure-sdk-for-js/blob/main/sdk/communication/communication-identity/samples/v1/typescript/src/revokeTokens.ts
[apiref]: https://docs.microsoft.com/javascript/api/@azure/communication-identity
[freesub]: https://azure.microsoft.com/free/
[createinstance_azurecommunicationservicesaccount]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource
[package]: https://github.com/Azure/azure-sdk-for-js/tree/main/sdk/communication/communication-identity/README.md
[typescript]: https://www.typescriptlang.org/docs/home.html
