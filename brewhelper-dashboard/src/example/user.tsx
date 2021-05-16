import React from 'react';
import { Datagrid, EmailField, List, TextField, UrlField } from 'react-admin';
import MyUrlField from './myUrlField';

export function UserList(props: any) {
  return (
    <List {...props}>
      <Datagrid rowClick="edit">
        <TextField source="id" />
        <TextField source="name" />
        <EmailField source="email" />
        <TextField source="phone" />
        <MyUrlField source="website" />
        <TextField source="company.name" />
      </Datagrid>
    </List>
  );
}
