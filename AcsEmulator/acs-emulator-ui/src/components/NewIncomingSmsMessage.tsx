import { useState } from 'react';

import {
  DefaultButton,
  PrimaryButton,
  Stack,
  TextField
} from '@fluentui/react';

import { raiseSmsReceivedEvent } from '../services/sms';

export interface NewIncomingSmsMessageProps {
  from: string,
  to: string,
  onClosed(): void
}

export const NewIncomingSmsMessage = (props: NewIncomingSmsMessageProps) => {
  const [from, setFrom] = useState<string>(props.from);
  const [to, setTo] = useState<string>(props.to);
  const [message, setMessage] = useState<string>('');

  const onFromChanged = (_event: React.FormEvent<HTMLInputElement | HTMLTextAreaElement>, newValue?: string) => {
    if (newValue) {
      setFrom(newValue);
    } else {
      setFrom('');
    }
  }

  const onToChanged = (_event: React.FormEvent<HTMLInputElement | HTMLTextAreaElement>, newValue?: string) => {
    if (newValue) {
      setTo(newValue);
    } else {
      setTo('');
    }
  }

  const onMessageChanged = (_event: React.FormEvent<HTMLInputElement | HTMLTextAreaElement>, newValue?: string) => {
    if (newValue) {
      setMessage(newValue);
    } else {
      setMessage('');
    }
  }

  const onSendClicked = async () => {
    await raiseSmsReceivedEvent(from, to, message);
    props.onClosed();
  }

  const onCancelClicked = () => {
    props.onClosed();
  }

  return (
    <Stack tokens={{childrenGap: 15}}>
      <TextField label='From' defaultValue={from} onChange={onFromChanged} />
      <TextField label='To' defaultValue={to} onChange={onToChanged} />
      <TextField label='Message' multiline defaultValue={message} onChange={onMessageChanged} />
      <Stack horizontal tokens={{childrenGap: 15}}>
        <PrimaryButton text='Send' onClick={onSendClicked} />
        <DefaultButton text='Cancel' onClick={onCancelClicked} />
      </Stack>
    </Stack>
  );
}