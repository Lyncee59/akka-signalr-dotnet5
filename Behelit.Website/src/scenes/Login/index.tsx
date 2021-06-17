import { ChangeEvent, useCallback, useState } from 'react';
import { Box, Flex } from 'reflexbox';
import { Input } from 'components/Inputs';
import Card from 'components/Containers/Card';
import { PrimaryButton } from 'components/Buttons';
import { login } from 'services/apiClient';

const Login = () => {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');

  const handleUsernameChange = useCallback((e: ChangeEvent<HTMLInputElement>) => {
    setUsername(e.target.value);
  }, []);

  const handlePasswordChange = useCallback((e: ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  }, []);

  const handleClick = () => {
    login(username, password);
  };

  return (
    <Flex justifyContent="center" alignItems="center" height="100%">
      <Card>
        <Flex flexDirection="column">
          <Box mb={2}>
            <Input type="text" width="300px" placeholder="Username" onChange={handleUsernameChange} />
          </Box>
          <Box mb={2}>
            <Input type="password" width="300px" placeholder="Password" onChange={handlePasswordChange} />
          </Box>
          <Box>
            <PrimaryButton onClick={handleClick}>Login</PrimaryButton>
          </Box>
        </Flex>
      </Card>
    </Flex>
  );
};

export default Login;
