import { Nav, INavStyles, INavLinkGroup } from '@fluentui/react';
import { useNavigate } from 'react-router-dom';

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

  const navigate = useNavigate();

  const navLinkGroups: INavLinkGroup[] = [
    {
      links: [
        {
          name: 'Quickstart',
          url: '/',
          icon: 'GiftboxOpen',
          key: 'quickstart'
        },
        {
          name: 'Identities',
          url: '/IdentitiesUI',
          icon: 'People',
          key: 'identities'
        },
        {
          name: 'Chats',
          url: '/ChatsUI',
          icon: 'CannedChat',
          key: 'chats'
        },
        {
          name: 'SMS',
          url: '/SMSUI',
          icon: 'Message',
          key: 'sms'
        },
        {
          name: 'Email',
          url: '/EmailUI',
          icon: 'Mail',
          key: 'email'
        }
      ],
    },
  ];

  return (
    <Nav
      onLinkClick={(event, element) => {
        event?.preventDefault();
        if (element) {
          navigate(element.url);
        }
      }}
      styles={navStyles}
      groups={navLinkGroups}
    />
  );
}