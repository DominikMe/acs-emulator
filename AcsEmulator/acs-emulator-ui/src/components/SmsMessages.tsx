import { useEffect, useState } from 'react';
import { 
  Stack,
  IStackTokens,
  CommandBar,
  ICommandBarItemProps,
  IColumn,
  ShimmeredDetailsList,
  SelectionMode
} from '@fluentui/react';
import { SmsMessage, getAll as getAllSmsMessages } from '../services/sms';

export const SmsMessages = () => {
  const [loadedSmsMessages, setLoadedSmsMessages] = useState<SmsMessage[] | undefined>(undefined);

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

  useEffect(() => {
    refreshMessagesClicked();
  }, [])

  const commands: ICommandBarItemProps[] = [
    {
      key: 'refresh',
      text: 'Refresh',
      iconProps: { iconName: 'Refresh' },
      onClick: refreshMessagesClicked
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
      <ShimmeredDetailsList
        items={loadedSmsMessages || []}
        enableShimmer={!loadedSmsMessages}
        columns={columns}
        selectionMode={SelectionMode.none}
      />
    </Stack>
  );
}