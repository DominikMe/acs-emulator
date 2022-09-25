import { Stack, IStackTokens, Text, TextField, Link } from '@fluentui/react';

export const Quickstart = () => {

  const stackTokens: IStackTokens ={
    childrenGap: 20,
    padding: 20
  }

  return (
    <Stack tokens={stackTokens}>
      <Text variant='large'>Congratulations! Your Azure Communication Services Emulator is running.</Text>
      <Text>Connect a sample app to it, or browse the <Link href='https://localhost/swagger/index.html'>Swagger API definition.</Link></Text>
      <TextField label='Endpoint' readOnly defaultValue='https://localhost'/>
      <TextField label='Connection String' readOnly defaultValue='endpoint=https://localhost/;accessKey=pw=='/>
    </Stack>
  );
}