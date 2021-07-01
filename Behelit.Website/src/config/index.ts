import { Config } from './types';

const config: Config = {
  environment: {
    authApiUrl: 'http://auth.behelit.com',
    publicApiUrl: 'http://api.behelit.com',
    websocketUrl: 'http://websocket.behelit.com/message'
  }
};

export default config;
