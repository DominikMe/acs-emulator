import { mergeStyles } from '@fluentui/react';
import acsLogo from '../assets/acs-logo.png';

export const Header = () => {
  const textColor = '#a5ce00';

  const headerStyles = mergeStyles({
    height: '60px',
    background: 'black'
  });

  const titleStyles = mergeStyles({
    verticalAlign: 'middle',
    color: textColor
  });

  const createAccountStyles = mergeStyles({
    float: 'right',
    lineHeight: '60px',
    paddingRight: '10px',
    textDecoration: 'none',
    color: textColor
  });

  return (
    <div className={headerStyles}>
      <span className={titleStyles}>
        <img src={acsLogo} height='60px' alt='Azure Communication Services logo' />
      </span>
      <span className={titleStyles}>Azure Communication Services Emulator</span>
      <a href="https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource" target='_blank' rel='noreferrer'>
        <span className={createAccountStyles}>CREATE AN AZURE COMMUNICATION SERVICES ACCOUNT &gt;</span>
      </a>
    </div>
  );
}