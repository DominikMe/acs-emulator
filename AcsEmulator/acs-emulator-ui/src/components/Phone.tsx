import {
  IStackTokens,
  IconButton, Pivot, PivotItem, Stack,
} from '@fluentui/react';
import { Dialpad } from '@azure/communication-react';
import { PhoneConnection, establishPhoneConnection, raiseIncomingCallEvent } from '../services/phone';
import { useEffect, useState } from 'react';
import { Route, Routes } from 'react-router';
import { useNavigate } from 'react-router-dom';

const phoneNumber = '+12345556789';
const acsPhoneNumber = '+1 (234) 555-000';

interface ActiveCall { 
  callerId: string,
  callerDisplayName: string,
  callState: "ringing" | "connected" | "terminated",
  startTime: Date
}

export const Phone = () => {
  const [getPhoneConnection, setPhoneConnection] = useState<PhoneConnection | undefined>(undefined);
  const [getDialedNumber, setDialedNumber] = useState<string | undefined>(undefined);
  const [getActiveCall, setActiveCall] = useState<ActiveCall | undefined>(undefined);
  const [getUtterance, setUtterance] = useState<SpeechSynthesisUtterance | undefined>(undefined);

  useEffect(() => {
    (async () => {
      const phoneConnection = await establishPhoneConnection(phoneNumber);
      phoneConnection.webSocket.onmessage = (event) => {
        handleMessage(event);
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

  const acceptCall = () => {
    // instantiate here because browsers require user interaction to create an utterance
    setUtterance(new SpeechSynthesisUtterance('Call connected'));
  };

  const rejectCall = () => {
  };

  const textToSpeech = (text: string) => {
    const utterance = getUtterance;
    if (!utterance) {
      console.error('SpeechSynthesisUtterance not instantiated');
      return;
    }
    utterance.text = text;
    utterance.voice = speechSynthesis.getVoices()[0];
    speechSynthesis.speak(utterance);
  }

  const handleMessage = (event: MessageEvent) => {
    const message = JSON.parse(event.data);
    console.log(message);

    switch (message.action) {
      case 'incomingCall':
        setActiveCall({
          callerId: message.callerId,
          callerDisplayName: message.callerDisplayName,
          startTime: new Date(message.time),
          callState: 'ringing'
        });
        navigate('/PhoneUI/incomingCall');
        break;
      case 'playText':
        // todo: check that call is connected, skipping for now until we have the full client to service flow
        textToSpeech(message.text);
    }
  };

  const incomingCallTokens: IStackTokens = {
    childrenGap: 10,
    padding: 10,
  };

  const navigate = useNavigate();
  
  return (
    <Stack>
      <div style={{
        width: '400px',
        height: '50%',
        position: 'relative',
        margin: '0 auto',
        padding: '1rem'
      }}>
        <Routes>
            <Route index={true} path="/dialScreen"
              element={(<Stack verticalAlign='center' style={{
                height: "100%"}}>
                <Stack.Item align="center">
                  <h3>Call {acsPhoneNumber}</h3>
                </Stack.Item>
                <Dialpad dialpadMode={'dialer'} onChange={(input) => {setDialedNumber(input)}}/>
                <Stack.Item align="center">
                  <IconButton
                    iconProps={{ iconName: 'Phone' }}   
                    title="Call"
                    ariaLabel="Call"
                    styles={{ root: { width: '4rem', height: '4rem' }, icon: { fontSize: '2rem', color: 'green' }}}
                    onClick={(ev) => {
                      callNumber();
                    }} />
                </Stack.Item>
              </Stack>)}
            />
            <Route path="/incomingCall" element={(
              <Stack tokens={incomingCallTokens} verticalAlign="center" style={{
                  height: "100%",
                  background: 'linear-gradient(to bottom right, turquoise, pink)'
                }}>
                <Stack.Item align="center">
                  <h4>Call from {getActiveCall?.callerId}</h4>
                  {!!getActiveCall?.callerDisplayName && <h2>{getActiveCall.callerDisplayName}</h2>}
                </Stack.Item>
                <Stack.Item align="center">
                  <IconButton
                    iconProps={{iconName: "Phone"}}
                    title='Answer'
                    ariaLabel="Answer"
                    styles={{ root: { width: '4rem', height: '4rem', padding: '0 auto' }, icon: { fontSize: '2rem', color: 'green' }}}
                    onClick={(ev) => {
                      acceptCall();
                    }}>
                    Answer
                  </IconButton>
                  <IconButton
                    iconProps={{iconName: "DeclineCall"}}
                    title='Decline'
                    ariaLabel="Decline"
                    styles={{ root: { width: '4rem', height: '4rem',  padding: '0 auto' }, icon: { fontSize: '2rem', color: 'red' }}}>
                    Decline
                  </IconButton>
                </Stack.Item>
              </Stack>)}/>
            <Route path="/whatsApp" />
        </Routes>
      </div>
      <Pivot
        onLinkClick={(item) => {
          if (item) {
            console.log(item.props.itemKey!);
            navigate(`/PhoneUI/${item.props.itemKey!}`);
          }
        }}>
        <PivotItem itemIcon="Phone" headerText="Phone" itemKey="dialScreen" />
        <PivotItem itemIcon="OfficeChat" headerText="WhatsApp" itemKey="whatsApp" />
      </Pivot>
    </Stack>
  );
}