/* eslint-disable import/no-anonymous-default-export */
import jwt_decode from 'jwt-decode';
const apiUrl = '/api';

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
        const decodedToken = jwt_decode(auth.token) as any;
        localStorage.setItem('auth', JSON.stringify(auth));
        localStorage.setItem(
          'permissions',
          decodedToken[
            'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
          ]
        );
      })
      .catch((err) => {
        throw new Error(err.message);
      });
  },

  // called when the user clicks on the logout button
  logout: () => {
    localStorage.removeItem('auth');
    localStorage.removeItem('permissions');
    return Promise.resolve();
  },

  // called when the API returns an error
  checkError: (response: any) => {
    if (response.status === 401 || response.status === 403) {
      localStorage.removeItem('auth');
      localStorage.removeItem('permissions');
      return Promise.reject();
    }
    return Promise.resolve();
  },
  // called when the user navigates to a new location, to check for authentication
  checkAuth: () => {
    return localStorage.getItem('auth') ? Promise.resolve() : Promise.reject();
  },
  // called when the user navigates to a new location, to check for permissions / roles
  getPermissions: () => {
    const roles = localStorage.getItem('permissions')?.split(',');
    if (roles != null) {
      return Promise.resolve(roles);
    } else {
      return Promise.reject();
    }
    //return roles ? Promise.resolve(roles) : Promise.reject();
  },
};

export interface Auth {
  token: string;
  expiration: Date;
}
