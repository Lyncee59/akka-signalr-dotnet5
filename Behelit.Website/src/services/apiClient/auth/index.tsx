import { post } from '../client';

export const login = (username: string, password: string) => post('/auth/login', { username, password });
