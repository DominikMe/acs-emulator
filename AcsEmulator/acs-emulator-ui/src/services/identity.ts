import { CommunicationUserIdentifier } from '@azure/communication-common';
import { ApiUrl } from './apiUrl';

const baseUrl = `${ApiUrl}/identities`;

export const getAll = async (): Promise<CommunicationUserIdentifier[]>  => {
  const response = await fetch(baseUrl);
  

  let identities: CommunicationUserIdentifier[] = [];
  const data = await response.json();

  for (let item of data.value) {
    identities.push({ communicationUserId: item.id });
  }
  
  return identities;
}