import { get, post } from '../clients/auth';

export const authenticate = (username: string, password: string) => post('/users/authenticate', { username, password });

export const refreshToken = () => post('/Users/refreshToken');

export const revokeToken = (token: string) => post('/Users/revoke-token', { token });

export const getAllUsers = () => get('/Users');

export const getUser = (id: string) => get(`/Users/${id}`);

export const refreshUserToken = (id: string) => get(`/Users/${id}/refresh-tokens`);
