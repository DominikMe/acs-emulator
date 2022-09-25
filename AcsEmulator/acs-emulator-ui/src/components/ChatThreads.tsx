import { useState } from 'react';
import { 
  Stack,
  IStackTokens,
  CommandBar,
  ICommandBarItemProps,
  IColumn,
  ShimmeredDetailsList,
  SelectionMode
} from '@fluentui/react';
import { ChatThreadProperties } from '@azure/communication-chat';
import { getAll as getAllChatThreads } from '../services/chatThread';

export const ChatThreads = () => {
  const [loadedChatThreads, setLoadedChatThreads] = useState<ChatThreadProperties[] | undefined>(undefined);

  const stackTokens: IStackTokens = {
    childrenGap: 5,
    padding: 15
  }

  const refreshChatThreadsClicked = (ev?: React.MouseEvent<HTMLElement> | React.KeyboardEvent<HTMLElement>) => {
    const getChatThreads = async () => {
      const threads = await getAllChatThreads();
      setLoadedChatThreads(threads);
    }
    
    getChatThreads();
  }

  const commands: ICommandBarItemProps[] = [
    {
      key: 'add',
      text: 'Add (TBD)',
      iconProps: { iconName: 'Add' },
      disabled: true
    },
    {
      key: 'refresh',
      text: 'Load/Refresh',
      iconProps: { iconName: 'Refresh' },
      onClick: refreshChatThreadsClicked
    },
    {
      key: 'delete',
      text: 'Delete (TBD)',
      iconProps: { iconName: 'Delete' },
      disabled: true
    },
  ];

  const columns: IColumn[] = [
    {
      key: 'id',
      name: 'Id',
      fieldName: 'id',
      minWidth: 250,
      maxWidth: 250,
      data: 'string'
    },
    {
      key: 'topic',
      name: 'Topic',
      fieldName: 'topic',
      minWidth: 150,
      data: 'string'
    },
    {
      key: 'createdOn',
      name: 'Created On',
      minWidth: 150,
      maxWidth: 150,
      isPadded: true,
      onRender: (item: ChatThreadProperties) => {
        return <span>{item.createdOn.toISOString()}</span>
      }
    },
    {
      key: 'createdBy',
      name: 'Created By',
      minWidth: 500,
      maxWidth: 500,
      onRender: (item: ChatThreadProperties) => {
        return item.createdBy?.kind === 'communicationUser' ? <span>{item.createdBy?.communicationUserId}</span> :
          <span></span>
      }
    }
  ];

  return (
    <Stack tokens={stackTokens}>
      <CommandBar items={commands}/>
      <ShimmeredDetailsList
        items={loadedChatThreads || []}
        enableShimmer={!loadedChatThreads}
        columns={columns}
        selectionMode={SelectionMode.none}
      />
    </Stack>
  );
}