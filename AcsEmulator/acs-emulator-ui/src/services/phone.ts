import { ApiUrl } from "./apiUrl"

export const raiseIncomingCallEvent = async (from: string, to: string): Promise<void> => {
  const data = {
    from: from,
    to: to
  }

  await fetch(`${ApiUrl}/admin/callAutomation:raiseIncomingCallEvent`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });
};

export class PhoneConnection {
  public readonly webSocket: WebSocket;

  constructor(phoneNumber: string) {
    this.webSocket = new WebSocket(`wss://${(new URL(ApiUrl).host)}/admin/callAutomation/sockets/${phoneNumber}`);
  }

  async establishConnection(): Promise<WebSocket> {
    return new Promise((resolve, reject) => {
      this.webSocket.onopen = () => {
        setInterval(this.keepAlive.bind(this), 5000);
        resolve(this.webSocket);
      }

      this.webSocket.onerror = (error) => {
        reject(error);
      }

      this.webSocket.onclose = (event) => {
        console.log('WebSocket closed', event);
      }
    });
  }

  async keepAlive(): Promise<void> {
    console.log("keep websocket alive");
    if (this.webSocket.readyState === WebSocket.OPEN) {
      this.webSocket.send(JSON.stringify({ action: "keepAlive", content: "" }));
    }
    else {
      console.error('WebSocket not open');
    }
  }
}

export const establishPhoneConnection = async (phoneNumber: string): Promise<PhoneConnection> => {
  const phoneWebSocket = new PhoneConnection(phoneNumber);
  await phoneWebSocket.establishConnection();
  return phoneWebSocket;
}