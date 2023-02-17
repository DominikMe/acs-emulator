import express from "express";
import * as dotenv from "dotenv";

dotenv.config();
const app = express();

app.use(express.json());

app.post("/webhook", (req, res) => {
  // console.log('Got callback. Body');
  // console.log(req.body);

  const validationEventType = "Microsoft.EventGrid.SubscriptionValidationEvent";
  const deliveryReportEventType = "Microsoft.Communication.SMSDeliveryReportReceived";
  const smsReceivedEventType = "Microsoft.Communication.SMSReceived";

  for (var events in req.body) {
    var body = req.body[events];
    // Deserialize the event data into the appropriate type based on event type
    if (body.data && body.eventType == validationEventType) {
        console.log("Got SubscriptionValidation event data, validation code: " + body.data.validationCode + " topic: " + body.topic);

        // Do any additional validation (as required) and then return back the below response
        var code = body.data.validationCode;
        res.status(200).json({ "ValidationResponse": code });
    }
    else if (body.data && body.eventType == deliveryReportEventType) {
      console.log("Got delivery reoport event data, report details:");
      console.log({
        from: body.data.from,
        to: body.data.to,
        deliveryStatus: body.data.deliveryStatus,
        deliveryStatusDetails: body.data.deliveryStatusDetails,
        tag: body.data.tag
      });
    }
    else if (body.data && body.eventType == smsReceivedEventType) {
      console.log("Got incoming SMS message, details:");
      console.log({
        from: body.data.from,
        to: body.data.to,
        message: body.data.message
      });
    }
  }
});

const port = process.env.LISTEN_PORT || "8080";
app.listen(port, () => {
  console.log(`Listening on port ${port}`);
});