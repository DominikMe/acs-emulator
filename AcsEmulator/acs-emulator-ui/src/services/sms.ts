export interface SmsMessage {
  id: string,
  from: string,
  to: string,
  message: string,
  enableDeliveryReport: boolean,
  tag?: string
}

export const getAll = async (): Promise<SmsMessage[]>  => {
  const response = await fetch('/admin/sms');
  
  let messages: SmsMessage[] = [];
  const data = await response.json();

  for (let item of data.value) {
    messages.push({
      id: item.id,
      from: item.from,
      to: item.to,
      message: item.message,
      enableDeliveryReport: item.enableDeliveryReport,
      tag: item.tag
    });
  }

  return messages;
}