import { CommunicationUserIdentifier } from '@azure/communication-common';

const baseUrl = '/identities';

export const getAll = async (): Promise<CommunicationUserIdentifier[]>  => {
  const response = await fetch(baseUrl);
  

  let identities: CommunicationUserIdentifier[] = [];
  const data = await response.json();

  for (let item of data.value) {
    identities.push({ communicationUserId: item.id });
  }
  
  return identities;
}