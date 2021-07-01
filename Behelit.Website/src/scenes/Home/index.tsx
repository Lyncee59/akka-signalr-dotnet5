import { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';
import { Box, Flex } from 'reflexbox';
import { PrimaryButton } from '../../components/Buttons';
import config from 'config';

console.log('config.environment.websocketUrl', config.environment.websocketUrl);

const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl(config.environment.websocketUrl)
  .configureLogging(signalR.LogLevel.Trace)
  .build();

interface Message {
  date: Date;
  message: string;
}

const App = () => {
  const [messages, setMessages] = useState<Message[]>([]);

  const handleMessages = (message: string) => {
    console.log('message recu : ' + message);
    setMessages((prevMessages) => [...prevMessages, { date: new Date(), message }]);
  };

  useEffect(() => {
    if (hubConnection.state === 'Disconnected') {
      console.log('Init websocket connection');
      hubConnection.start();
      setMessages([]);
    }

    hubConnection.on('broadcast', handleMessages);

    return () => {
      hubConnection.off('broadcast', handleMessages);
    };
  }, []);

  const handleClick = () => {
    hubConnection.send('Ping');
  };

  return (
    <Flex flexDirection="column">
      {messages.map((message) => (
        <Flex key={message.message}>
          <Box>{message.message}</Box>
        </Flex>
      ))}
      <PrimaryButton onClick={handleClick}>Ping</PrimaryButton>
    </Flex>
  );
};

export default App;
