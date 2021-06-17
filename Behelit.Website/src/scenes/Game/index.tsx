import { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';
import { Flex } from 'reflexbox';
import { PrimaryButton } from '../../components/Buttons';
import config from 'config';

const hubConnection = new signalR.HubConnectionBuilder().withUrl(config.environment.websocketUrl).build();

const App = () => {
  const [name, setName] = useState<string>('lyncee');

  const handleInputUpdate = (e: React.ChangeEvent<HTMLInputElement>) => setName(e.target.value);

  const handleClickPing = () => {
    hubConnection.send('Ping');
  };

  const handleClickJoin = () => {
    console.log('SendPlayerCommand', name, 'Join');
    hubConnection.send('SendPlayerCommand', name, 'Join', '');
  };

  const handleClickLeave = () => {
    console.log('SendPlayerCommand', name, 'Leave');
    hubConnection.send('SendPlayerCommand', name, 'Leave', '');
  };

  const handleClickMove = () => {
    hubConnection.send('SendPlayerCommand', name, 'Move', JSON.stringify({ playerDirection: 'up' }));
  };

  const handlePlayerPositionUpdated = (e: any) => {
    console.log('broadcast', e);
  };

  useEffect(() => {
    if (hubConnection.state === 'Disconnected') {
      console.log('Start connection...');
      hubConnection.start();
    }

    hubConnection.on('playerEvent', handlePlayerPositionUpdated);
    hubConnection.on('PlayerPositionUpdated', () => {
      console.log('PlayerPositionUpdated');
    });
    hubConnection.on('broadcast', (data) => {
      console.log('broadcast', data);
    });

    return () => {
      hubConnection.off('playerEvent', handlePlayerPositionUpdated);
    };
  }, [hubConnection.state]);

  return (
    <Flex flexDirection="column">
      <Flex flexDirection="row">
        <input type="text" onChange={handleInputUpdate} value={name} />
        <PrimaryButton onClick={handleClickPing}>Ping</PrimaryButton>
        <PrimaryButton onClick={handleClickJoin}>Join</PrimaryButton>
        <PrimaryButton onClick={handleClickLeave}>Leave</PrimaryButton>

        <PrimaryButton onClick={handleClickMove}>Move Up</PrimaryButton>
      </Flex>
    </Flex>
  );
};

export default App;
