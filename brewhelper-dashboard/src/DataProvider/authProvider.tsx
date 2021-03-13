/* eslint-disable import/no-anonymous-default-export */

const apiUrl = 'https://localhost:5001/api';

export default {
  // called when the user attempts to log in
  login: ({ username, password }: any) => {
    const request = new Request(`${apiUrl}/Authentication/login`, {
      method: 'POST',
      body: JSON.stringify({ username, password }),
      headers: new Headers({ 'Content-Type': 'application/json' }),
    });
    return fetch(request)
      .then((response) => {
        if (response.status === 401) {
          throw new Error('Unauthorized');
        }
        if (response.status < 200 || response.status >= 300) {
          throw new Error(response.statusText);
        }
        return response.json();
      })
      .then((auth: Auth) => {
        localStorage.setItem('auth', JSON.stringify(auth));
      })
      .catch((err) => {
        throw new Error(err.message);
      });
  },

  // called when the user clicks on the logout button
  logout: () => {
    localStorage.removeItem('auth');
    return Promise.resolve();
  },

  // called when the API returns an error
  checkError: (status: number) => {
    if (status === 401 || status === 403) {
      localStorage.removeItem('auth');
      return Promise.reject();
    }
    return Promise.resolve();
  },
  // called when the user navigates to a new location, to check for authentication
  checkAuth: () => {
    return localStorage.getItem('auth') ? Promise.resolve() : Promise.reject();
  },
  // called when the user navigates to a new location, to check for permissions / roles
  getPermissions: () => Promise.resolve(),
};

export interface Auth {
  token: string;
  expiration: Date;
}
