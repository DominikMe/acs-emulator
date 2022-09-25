import { ChatThreadProperties } from '@azure/communication-chat'
// import { CommunicationUserIdentifier } from '@azure/communication-common';

export const getAll = async (): Promise<ChatThreadProperties[]>  => {
  //const response = await fetch('/admin/chat/threads');
  

  let threads: ChatThreadProperties[] = [];
  //const data = await response.json();

  // for (let item of data.value) {
  //   threads.push({  });
  // }

  threads.push({
    id: 'sdfsdf',
    topic: 'My interesting topic',
    createdOn: new Date(),
    createdBy: {
      kind: 'communicationUser',
      communicationUserId: '123'
    }
  });

  threads.push({
    id: 'sdfsdf',
    topic: 'My interesting topic',
    createdOn: new Date(),
    createdBy: {
      kind: 'communicationUser',
      communicationUserId: '123'
    }
  });

  threads.push({
    id: 'sdfsdf',
    topic: 'My interesting topic',
    createdOn: new Date(),
    createdBy: {
      kind: 'communicationUser',
      communicationUserId: '123'
    }
  });

  threads.push({
    id: 'sdfsdf',
    topic: 'My interesting topic',
    createdOn: new Date()
  });
  
  return threads;
}