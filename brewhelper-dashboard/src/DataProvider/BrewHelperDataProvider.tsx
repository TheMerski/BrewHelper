/* eslint-disable import/no-anonymous-default-export */
import { fetchUtils } from 'react-admin';
import { stringify } from 'query-string';
import { CreateIngredientQueryFilter } from '../models/Ingredient';
import { CreateRecipeQueryFilter } from '../models/Recipe';

const apiUrl = '/api';

const httpClient = (apiUrl: string, options: any = {}) => {
  if (!options.headers) {
    options.headers = new Headers({ Accept: 'application/json' });
  }
  const { token } = JSON.parse(localStorage.getItem('auth')!);
  options.headers.set('Authorization', `Bearer ${token}`);
  return fetchUtils.fetchJson(apiUrl, options);
};

export default {
  getList: (resource: any, params: any) => {
    const { page, perPage } = params.pagination;
    const { field, order } = params.sort;
    const query = {
      sort: JSON.stringify([field, order]),
      range: JSON.stringify([(page - 1) * perPage, page * perPage - 1]),
    };

    let filters = '';
    if (resource === 'Ingredients')
      filters = CreateIngredientQueryFilter(params.filter);
    if (resource === 'Recipes')
      filters = CreateRecipeQueryFilter(params.filter);

    const url = `${apiUrl}/${resource}?${stringify(query)}${filters}`;

    return httpClient(url).then(({ headers, json }) => ({
      data: json.items,
      total: json.totalItems,
    }));
  },

  getOne: (resource: any, params: any) =>
    httpClient(`${apiUrl}/${resource}/${params.id}`).then(({ json }) => ({
      data: json,
    })),

  getMany: (resource: any, params: any) => {
    let query = '';
    for (let id of params.ids) {
      query += `&Id=${id}`;
    }
    const url = `${apiUrl}/${resource}?${query}`;
    return httpClient(url).then(({ json }) => ({ data: json.items }));
  },

  getManyReference: (resource: any, params: any) => {
    const { page, perPage } = params.pagination;
    const { field, order } = params.sort;
    const query = {
      sort: JSON.stringify([field, order]),
      range: JSON.stringify([(page - 1) * perPage, page * perPage - 1]),
      filter: JSON.stringify({
        ...params.filter,
        [params.target]: params.id,
      }),
    };
    const url = `${apiUrl}/${resource}?${stringify(query)}`;

    return httpClient(url).then(({ headers, json }) => ({
      data: json,
      total: 1,
      //total: parseInt(headers.get('content-range').split('/').pop(), 10),
    }));
  },

  update: (resource: any, params: any) =>
    httpClient(`${apiUrl}/${resource}/${params.id}`, {
      method: 'PUT',
      body: JSON.stringify(params.data),
    }).then(({ json }) => ({ data: json })),

  updateMany: (resource: any, params: any) => {
    const query = {
      filter: JSON.stringify({ id: params.ids }),
    };
    return httpClient(`${apiUrl}/${resource}?${stringify(query)}`, {
      method: 'PUT',
      body: JSON.stringify(params.data),
    }).then(({ json }) => ({ data: json }));
  },

  create: (resource: any, params: any) =>
    httpClient(`${apiUrl}/${resource}`, {
      method: 'POST',
      body: JSON.stringify(params.data),
    }).then(({ json }) => ({
      data: { ...params.data, id: json.id },
    })),

  delete: (resource: any, params: any) =>
    httpClient(`${apiUrl}/${resource}/${params.id}`, {
      method: 'DELETE',
    }).then(({ json }) => ({ data: json })),

  deleteMany: (resource: any, params: any) => {
    const query = {
      filter: JSON.stringify({ id: params.ids }),
    };
    return httpClient(`${apiUrl}/${resource}?${stringify(query)}`, {
      method: 'DELETE',
      body: JSON.stringify(params.data),
    }).then(({ json }) => ({ data: json }));
  },

  updatePassword: ({ CurrentPassword, NewPassword }: any) => {
    return httpClient(`${apiUrl}/Profile/updatePassword`, {
      method: 'POST',
      body: JSON.stringify({ CurrentPassword, NewPassword }),
    }).then((res) => {
      if (res.status === 200) {
        return Promise.resolve({ data: true });
      }
      return Promise.reject();
    });
  },
};
