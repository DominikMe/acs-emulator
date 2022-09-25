import { mergeStyles, Text, Link } from '@fluentui/react';
import acsLogo from '../assets/acs-logo.png';

export const Header = () => {
  const headerStyles = mergeStyles({
    height: '60px',
    border: '1px solid #eee'
  });

  const titleStyles = mergeStyles({
    verticalAlign: 'middle',
  });

  const createAccountStyles = mergeStyles({
    float: 'right',
    lineHeight: '60px',
    paddingRight: '10px',
    textDecoration: 'none',
  });

  return (
    <div className={headerStyles}>
      <span className={titleStyles}>
        <img src={acsLogo} height='60px' alt='Azure Communication Services logo' />
      </span>
      <span className={titleStyles}>
        <Text variant='large'>Azure Communication Services Emulator</Text>
      </span>
      <Link href="https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource" target='_blank'>
        <span className={createAccountStyles}>
          <Text variant='xLarge'>CREATE AN AZURE COMMUNICATION SERVICES ACCOUNT &gt;</Text>
        </span>
      </Link>
    </div>
  );
}