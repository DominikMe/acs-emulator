// subset
export interface EmailMessage {
  operationId: string,
  from: string,
  to: string,
  cc: string,
  bcc: string,
  subject: string,
  plainText: string,
  html: string,
  replyTo: string,
  attachments: string,
  disableUserEngagementTracking: boolean
}

export const getAllEmails = async (): Promise<EmailMessage[]>  => {
  const response = await fetch('/admin/emails');  
  const data = await response.json();
  for (const email of data.value) {
    email.attachments = email.attachments.map((x: { name: string; }) => x.name).join(',')
  }
  return data.value;
}