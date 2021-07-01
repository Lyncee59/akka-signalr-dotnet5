import { query } from './query';

import config from 'config';

const domain = config.environment.authApiUrl;

export const get = async <T>(url: string): Promise<T> =>
  query(`${domain}${url}`, {
    method: 'GET'
  });

export const post = async <T>(url: string, data?: Record<string, unknown>): Promise<T> =>
  query(`${domain}${url}`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });

export const put = async <T>(url: string, data?: Record<string, unknown>): Promise<T> =>
  query(`${domain}${url}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });
