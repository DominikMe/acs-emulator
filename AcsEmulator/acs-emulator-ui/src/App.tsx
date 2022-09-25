import { Header } from './components/Header';
import { LeftNav } from './components/LeftNav';
import { Stack } from '@fluentui/react';

const App = () => {
  return (
    <>
      <Header />
      <Stack horizontal>
        <LeftNav />
        <div>
          HELLO EMULATOR WORLD
        </div>
      </Stack>
    </>
  );
}

export default App;
