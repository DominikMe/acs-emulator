import express from "express";
import * as dotenv from "dotenv";

dotenv.config();
const app = express();

app.use(express.json());

app.post("/webhook", (req, res) => {
  console.log("got request:");
  console.log(req.body);

  res.status(200).send();
});

const port = process.env.LISTEN_PORT || "8080";
app.listen(port, () => {
  console.log(`Listening on port ${port}`);
});