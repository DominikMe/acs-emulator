import { Nav, INavStyles, INavLinkGroup } from '@fluentui/react';

export const LeftNav = () => {
  const navStyles: Partial<INavStyles> = {
    root: {
      width: '150px',
      height: '100vh',
      boxSizing: 'border-box',
      border: '1px solid #eee',
      overflowY: 'auto',
    },
  };

  const navLinkGroups: INavLinkGroup[] = [
    {
      links: [
        {
          name: 'Quickstart',
          url: '/',
          icon: 'GiftboxOpen'
        },
        {
          name: 'Identities',
          url: 'http://example.com',
          icon: 'People',
        },
        {
          name: 'Chats',
          url: 'http://msn.com',
          icon: 'CannedChat',
        },
        {
          name: 'SMS',
          url: 'http://msn.com',
          icon: 'Message',
          disabled: true,
        }
      ],
    },
  ];

  return (
    <Nav
      styles={navStyles}
      groups={navLinkGroups}
    />
  );
}