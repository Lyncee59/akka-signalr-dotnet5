import { Config } from './types';

const config: Config = {
  environment: {
    // authApiUrl: 'https://localhost:44308/api',
    // websocketUrl: 'https://localhost:44342/message'
    authApiUrl: 'http://auth.behelit.com/api',
    websocketUrl: 'http://websocket.behelit.com/message'
  }
};

export default config;
