import {
  IStackTokens,
  IconButton, Pivot, PivotItem, Stack,
} from '@fluentui/react';
import { Dialpad } from '@azure/communication-react';
import { PhoneConnection, establishPhoneConnection, raiseIncomingCallEvent } from '../services/phone';
import { useEffect, useRef, useState } from 'react';
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
  const phoneConnection = useRef<PhoneConnection | undefined>(undefined);
  const [dialedNumber, setDialedNumber] = useState<string | undefined>(undefined);
  const [activeCall, setActiveCall] = useState<ActiveCall | undefined>(undefined);
  const utterance = useRef<SpeechSynthesisUtterance | undefined>(undefined);

  useEffect(() => {
    (async () => {
      const connection = await establishPhoneConnection(phoneNumber);
      connection.webSocket.onmessage = (event) => {
        handleMessage(event);
      };
      phoneConnection.current = connection;
    })();
  }, []);

  const callNumber = () => {
    const targetNumber = dialedNumber;
    if (targetNumber) {
      raiseIncomingCallEvent(phoneNumber, targetNumber);
    }
  };

  const acceptCall = () => {
    // instantiate here because browsers require user interaction to create an utterance
    utterance.current = new SpeechSynthesisUtterance();

    sendWebsocketMessage({ action: "acceptCall", content: "" });
  };

  const declineCall = () => {
    sendWebsocketMessage({ action: "declineCall", content: "" });
  };

  const sendWebsocketMessage = (message: { action: string, content: string }) => {
    const connection = phoneConnection.current;
    if (connection!.webSocket.readyState !== WebSocket.OPEN) {
      console.error('WebSocket not open');
      return;
    }
    connection!.webSocket.send(JSON.stringify(message));
  };

  const textToSpeech = (text: string) => {
    const utt = utterance.current;
    if (!utt) {
      console.error('SpeechSynthesisUtterance not instantiated');
      return;
    }
    utt.text = text;
    utt.voice = speechSynthesis.getVoices()[0];
    speechSynthesis.speak(utt);
  }

  const recognizeSpeech = (prompt: string) => {
    if (!!prompt) {
      textToSpeech(prompt);
    }
    
    // to do - implement speech recognition, see https://developer.mozilla.org/en-US/docs/Web/API/Web_Speech_API/Using_the_Web_Speech_API
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
        break;
      case 'recognizeSpeech':
          // todo: check that call is connected, skipping for now until we have the full client to service flow
          recognizeSpeech(message.prompt);
          break;
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
                  <h4>Call from {activeCall?.callerId}</h4>
                  {!!activeCall?.callerDisplayName && <h2>{activeCall.callerDisplayName}</h2>}
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
                    styles={{ root: { width: '4rem', height: '4rem',  padding: '0 auto' }, icon: { fontSize: '2rem', color: 'red' }}}
                    onClick={(ev) => {
                      declineCall();
                    }}>
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