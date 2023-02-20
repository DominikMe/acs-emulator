import { useEffect, useState } from 'react';
import { 
  Stack,
  IStackTokens,
  CommandBar,
  ICommandBarItemProps,
  IColumn,
  Modal,
  ShimmeredDetailsList,
  SelectionMode,
  Selection,
  IconButton
} from '@fluentui/react';
import { NewIncomingSmsMessage } from './NewIncomingSmsMessage';
import { SmsMessage, getAll as getAllSmsMessages } from '../services/sms';

export const SmsMessages = () => {
  const [loadedSmsMessages, setLoadedSmsMessages] = useState<SmsMessage[] | undefined>(undefined);
  const [replyButtonEnabled, setReplyButtonEnabled] = useState<boolean>(false);
  const [selectedItem, setSelectedItem] = useState<SmsMessage | undefined>(undefined);
  const [newIncomingMessageBoxVisible, setNewIncomingMessageBoxVisible] = useState<boolean>(false);
  const [newMessageFrom, setNewMessageFrom] = useState<string>('');
  const [newMessageTo, setNewMessageTo] = useState<string>('');

  const selection = new Selection({
    onSelectionChanged: () => {
      var selectedObjects = selection.getSelection();

      if (selectedObjects.length > 0) {
        setSelectedItem(selectedObjects[0] as SmsMessage);
        setReplyButtonEnabled(true);
      } else {
        setSelectedItem(undefined);
        setReplyButtonEnabled(false);
      }
    },
    selectionMode: SelectionMode.single
  });

  const stackTokens: IStackTokens = {
    childrenGap: 5,
    padding: 15
  }

  const refreshMessagesClicked = (ev?: React.MouseEvent<HTMLElement> | React.KeyboardEvent<HTMLElement>) => {
    const getSmsMessages = async () => {
      const messages = await getAllSmsMessages();
      setLoadedSmsMessages(messages);
    }
    
    getSmsMessages();
  }

  const newIncomingMessageButtonClicked = (ev?: React.MouseEvent<HTMLElement> | React.KeyboardEvent<HTMLElement>) => {
    setNewMessageFrom('');
    setNewMessageTo('');
    setNewIncomingMessageBoxVisible(true);
  }

  const replyButtonClicked = (ev?: React.MouseEvent<HTMLElement> | React.KeyboardEvent<HTMLElement>) => {
    if (selectedItem) {
      setNewMessageFrom(selectedItem?.from);
      setNewMessageTo(selectedItem?.to);
      setNewIncomingMessageBoxVisible(true);
    }
  }

  useEffect(() => {
    refreshMessagesClicked();
  }, [])

  const commands: ICommandBarItemProps[] = [
    {
      key: 'new',
      text: 'New',
      iconProps: { iconName: 'Message' },
      onClick: newIncomingMessageButtonClicked
    },
    {
      key: 'refresh',
      text: 'Refresh',
      iconProps: { iconName: 'Refresh' },
      onClick: refreshMessagesClicked
    },
    {
      key: 'reply',
      text: 'Reply',
      iconProps: { iconName: 'MailReply' },
      disabled: !replyButtonEnabled,
      onClick: replyButtonClicked
    },
  ];

  const columns: IColumn[] = [
    {
      key: 'id',
      name: 'Id',
      fieldName: 'id',
      minWidth: 150,
      data: 'string'
    },
    {
      key: 'from',
      name: 'From',
      fieldName: 'from',
      minWidth: 100,
      data: 'string'
    },
    {
      key: 'to',
      name: 'To',
      fieldName: 'to',
      minWidth: 100,
      data: 'string'
    },
    {
      key: 'message',
      name: 'Message',
      fieldName: 'message',
      minWidth: 150,
      maxWidth: 250,
      data: 'string'
    },
    {
      key: 'enableDeliveryReport',
      name: 'Report?',
      fieldName: 'enableDeliveryReport',
      minWidth: 50,
      data: 'boolean'
    }
  ];

  return (
    <Stack tokens={stackTokens}>
      <CommandBar items={commands}/>
      <Modal isOpen={newIncomingMessageBoxVisible}>
        <div>
          <Stack horizontal={true} tokens={{childrenGap: 15, padding: 5}}>
            <h2>Send Incoming SMS Message</h2>
            <IconButton
              iconProps={{iconName: 'Cancel'}}
              onClick={() => setNewIncomingMessageBoxVisible(false)}
            />
          </Stack>
        </div>
        <div style={{padding: 5}}>
          <NewIncomingSmsMessage
            from={newMessageFrom}
            to={newMessageTo}
          />
        </div>
      </Modal>
      <ShimmeredDetailsList
        items={loadedSmsMessages || []}
        enableShimmer={!loadedSmsMessages}
        columns={columns}
        selectionMode={SelectionMode.single}
        selection={selection}
      />
    </Stack>
  );
}