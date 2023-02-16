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
import { CommunicationUserIdentifier } from '@azure/communication-common';
import { getAll as getAllIdentities } from '../services/identity';

export const Identities = () => {
  const [loadedIdentities, setLoadedIdentities] = useState<CommunicationUserIdentifier[] | undefined>(undefined);

  const stackTokens: IStackTokens ={
    childrenGap: 5,
    padding: 15
  }

  const refreshIdentitiesClicked = (ev?: React.MouseEvent<HTMLElement> | React.KeyboardEvent<HTMLElement>) => {
    const getIdentities = async () => {
      const identities = await getAllIdentities();
      setLoadedIdentities(identities);
    }
    
    getIdentities();
  }

  useEffect(() => {
    refreshIdentitiesClicked();
  }, [])

  const commands: ICommandBarItemProps[] = [
    {
      key: 'add',
      text: 'Add (TBD)',
      iconProps: { iconName: 'Add' },
      disabled: true
    },
    {
      key: 'refresh',
      text: 'Refresh',
      iconProps: { iconName: 'Refresh' },
      onClick: refreshIdentitiesClicked
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
      fieldName: 'communicationUserId',
      minWidth: 500,
      maxWidth: 500,
      data: 'string'
    }
  ];
  
  return (
    <Stack tokens={stackTokens}>
      <CommandBar items={commands}/>
      <ShimmeredDetailsList
        items={loadedIdentities || []}
        enableShimmer={!loadedIdentities}
        columns={columns}
        selectionMode={SelectionMode.none}
      />
    </Stack>
  );
}