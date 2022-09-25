import { ChatThreadProperties } from '@azure/communication-chat'

export const getAll = async (): Promise<ChatThreadProperties[]>  => {
  const response = await fetch('/admin/chat/threads');
  
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