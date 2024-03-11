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
        resolve(this.webSocket);
      }

      this.webSocket.onerror = (error) => {
        reject(error);
      }
    });
  }
}

export const establishPhoneConnection = async (phoneNumber: string): Promise<PhoneConnection> => {
  const phoneWebSocket = new PhoneConnection(phoneNumber);
  await phoneWebSocket.establishConnection();
  return phoneWebSocket;
}