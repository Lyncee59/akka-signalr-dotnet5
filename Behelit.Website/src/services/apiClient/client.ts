import fetch from 'isomorphic-fetch';

import config from 'config';

const domain = config.environment.authApiUrl;

const query = async <T>(request: RequestInfo, options?: RequestInit): Promise<T> => {
  const response = await fetch(request, options);

  return response.json();
};

export const get = async <T>(url: string): Promise<T> =>
  query(`${domain}${url}`, {
    method: 'GET'
  });

export const post = async <T>(url: string, data: Record<string, unknown>): Promise<T> =>
  query(`${domain}${url}`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });

export const put = async <T>(url: string, data: Record<string, unknown>): Promise<T> =>
  query(`${domain}${url}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });
