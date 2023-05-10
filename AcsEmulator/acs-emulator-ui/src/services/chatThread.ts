import { ChatThreadProperties } from '@azure/communication-chat'
import { ApiUrl } from './apiUrl'

export const getAll = async (): Promise<ChatThreadProperties[]>  => {
  const response = await fetch(`${ApiUrl}/admin/chat/threads`);
  
  let threads: ChatThreadProperties[] = [];
  const data = await response.json();

  for (let item of data.value) {
    threads.push({
      id: item.id,
      topic: item.topic,
      createdOn: new Date(item.createdOn),
      createdBy: item.createdBy
    });
  }

  return threads;
}