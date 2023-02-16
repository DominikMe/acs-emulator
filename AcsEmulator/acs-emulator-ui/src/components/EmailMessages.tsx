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
import { EmailMessage, getAllEmails } from '../services/email';

export const EmailMessages = () => {
  const [loadedEmailMessages, setLoadedEmailMessages] = useState<EmailMessage[] | undefined>(undefined);

  const stackTokens: IStackTokens = {
    childrenGap: 5,
    padding: 15
  }

  const refreshMessagesClicked = (ev?: React.MouseEvent<HTMLElement> | React.KeyboardEvent<HTMLElement>) => {
    const getEmailMessages = async () => {
      const messages = await getAllEmails();
      setLoadedEmailMessages(messages);
    }
    
    getEmailMessages();
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
      key: 'operationId',
      name: 'Operation Id',
      fieldName: 'operationId',
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
      key: 'cc',
      name: 'Cc',
      fieldName: 'cc',
      minWidth: 100,
      data: 'string'
    },
    {
      key: 'bcc',
      name: 'Bcc',
      fieldName: 'bcc',
      minWidth: 100,
      data: 'string'
    },
    {
      key: 'subject',
      name: 'Subject',
      fieldName: 'subject',
      minWidth: 150,
      maxWidth: 250,
      data: 'string'
    },
    {
      key: 'plainText',
      name: 'Plain Text',
      fieldName: 'plainText',
      minWidth: 150,
      maxWidth: 250,
      data: 'string'
    },
    {
      key: 'html',
      name: 'HTML',
      fieldName: 'html',
      minWidth: 150,
      maxWidth: 250,
      data: 'string'
    },
    {
      key: 'replyTo',
      name: 'Reply To',
      fieldName: 'replyTo',
      minWidth: 100,
      data: 'string'
    },
    {
      key: 'attachments',
      name: 'Attachments',
      fieldName: 'attachments',
      minWidth: 100,
      data: 'string'
    },
    {
      key: 'disableUserEngagementTracking',
      name: 'Disable Tracking',
      fieldName: 'disableUserEngagementTracking',
      minWidth: 120,
      data: 'boolean'
    },
  ];

  return (
    <Stack tokens={stackTokens}>
      <CommandBar items={commands}/>
      <ShimmeredDetailsList
        items={loadedEmailMessages || []}
        enableShimmer={!loadedEmailMessages}
        columns={columns}
        selectionMode={SelectionMode.none}
      />
    </Stack>
  );
}