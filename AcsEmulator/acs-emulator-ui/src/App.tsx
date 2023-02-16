import { Header } from './components/Header';
import { LeftNav } from './components/LeftNav';
import { Quickstart } from './components/Quickstart';
import { Identities } from './components/Identities';
import { ChatThreads } from './components/ChatThreads';
import { SmsMessages } from './components/SmsMessages';
import { EmailMessages } from './components/EmailMessages';
import { Route, Routes } from 'react-router-dom';
import { Stack } from '@fluentui/react';

const App = () => {
  return (
    <>
      <Header />
      <Stack horizontal>
        <LeftNav />
        <Routes>
          <Route index={true} element={<Quickstart/>}/>
          <Route path='/IdentitiesUI' element={<Identities/>}/>
          <Route path='/ChatsUI' element={<ChatThreads/>}/>
          <Route path='/SMSUI' element={<SmsMessages/>}/>
          <Route path='/EmailUI' element={<EmailMessages/>}/>
        </Routes>
      </Stack>
    </>
  );
}

export default App;
