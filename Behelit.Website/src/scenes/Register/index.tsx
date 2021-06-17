import { Box, Flex } from 'reflexbox';
import { Input } from './../../components/Inputs';
import Card from '../../components/Containers/Card';
import { PrimaryButton } from '../../components/Buttons';

const Register = () => (
  <Flex justifyContent="center" alignItems="center" height="100%">
    <Card>
      <Flex flexDirection="column">
        <Box mb={2}>
          <Input width="300px" placeholder="Username" />
        </Box>
        <Box mb={2}>
          <Input width="300px" placeholder="Email" />
        </Box>
        <Box mb={2}>
          <Input width="300px" placeholder="Password" type="password" />
        </Box>
        <Box>
          <PrimaryButton>Register</PrimaryButton>
        </Box>
      </Flex>
    </Card>
  </Flex>
);

export default Register;
