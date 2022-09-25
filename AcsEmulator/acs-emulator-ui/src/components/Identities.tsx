import { useState } from 'react';
import { 
  Stack,
  IStackTokens,
  CommandBar,
  ICommandBarItemProps,
  IColumn,
  buildColumns,
  ShimmeredDetailsList,
  SelectionMode
} from '@fluentui/react';
import { useConst } from '@fluentui/react-hooks'
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
      onClick: refreshIdentitiesClicked
    },
    {
      key: 'delete',
      text: 'Delete (TBD)',
      iconProps: { iconName: 'Delete' },
      disabled: true
    },
  ];

  const columns: IColumn[] = useConst(() => {
    const ids: CommunicationUserIdentifier[] = [
      {
        communicationUserId: 'sampleid'
      }
    ]

    const cols = buildColumns(ids);
    for (const c of cols)
    {
      if (c.key === 'communicationUserId') {
        c.name = 'Id';
        c.minWidth = 500;
        c.maxWidth = 500;
      }
    }

    return cols;
  });

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