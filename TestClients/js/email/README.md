# Azure Communication Services - Email client library samples for JavaScript

These sample programs show how to use the JavaScript client libraries for Azure Communication Services - Email in some common scenarios.

| **File Name**                      | **Description**                           |
| ---------------------------------- | ----------------------------------------- |
| send-email-multi-recipients.js     | Sends an email with multiple recipients   |
| send-email.js                      | Sends an email with a single recipient    |
| send-email-with-attachments.js     | Sends an email with a txt file attachment |

## Setup

To run the samples using the published version of the package:

1. Install the dependencies using `npm`:

```bash
npm install
```

2. Edit the file `sample.env`, adding the correct credentials to access the Azure service and run the samples. Then rename the file from `sample.env` to just `.env`. The sample programs will read this file automatically.

3. Run whichever samples you like :

```bash
node ./send-email.js
```

## Next Steps

Take a look at [API Documentation][apiref] for more information about the APIs that are available in the clients.

[apiref]: https://docs.microsoft.com/javascript/api/@azure/communication-email
