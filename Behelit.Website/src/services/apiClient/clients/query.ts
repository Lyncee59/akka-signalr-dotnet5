import fetch from 'isomorphic-fetch';

export const query = async <T>(request: RequestInfo, options?: RequestInit): Promise<T> => {
  const response = await fetch(request, { ...options, credentials: 'include' });

  return response.json();
};
