import {
  IconButton,
} from '@fluentui/react';
import { Dialpad } from '@azure/communication-react';
import { PhoneConnection, establishPhoneConnection, raiseIncomingCallEvent } from '../services/phone';
import { useEffect, useState } from 'react';

const phoneNumber = '+112345556789'

export const Phone = () => {
  const [getPhoneConnection, setPhoneConnection] = useState<PhoneConnection | undefined>(undefined);
  const [getDialedNumber, setDialedNumber] = useState<string | undefined>(undefined);

  useEffect(() => {
    (async () => {
      const phoneConnection = await establishPhoneConnection(phoneNumber);
      phoneConnection.webSocket.onmessage = (event) => {
        const message = JSON.parse(event.data);
        console.log(message);
      };
      setPhoneConnection(phoneConnection);
    })();
  }, []);

  const callNumber = () => {
    const targetNumber = getDialedNumber;
    if (targetNumber) {
      raiseIncomingCallEvent(phoneNumber, targetNumber);
    }
  };
  
  return (
    <div>
      <h3>Call 1 (234) 555-000</h3>
      <Dialpad dialpadMode={'dialer'} onChange={(input) => {setDialedNumber(input)}}/>
      <IconButton
        iconProps={{ iconName: 'Phone' }}
        title="Call"
        ariaLabel="Call"
        styles={{ root: { width: '4rem', height: '4rem' }}}
        onClick={(ev) => {
          callNumber();
        }} />
    </div>
  );
}