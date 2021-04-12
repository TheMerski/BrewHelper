import React from 'react';
import {
  List,
  Datagrid,
  TextField,
  Edit,
  NumberInput,
  SimpleForm,
  TextInput,
  ArrayInput,
  SimpleFormIterator,
  ReferenceInput,
  Create,
  Filter,
  AutocompleteInput,
  NumberField,
  ReferenceField,
  TabbedForm,
  FormTab,
  EmailField,
} from 'react-admin';

const UserTitle: React.FC<{ record?: any }> = ({ record = {} }) => {
  return <span>User: {record ? `"${record.username}"` : ''}</span>;
};

function UserFilter(props: any) {
  return (
    <Filter {...props}>
      <TextInput label="Search" source="Name" alwaysOn />
    </Filter>
  );
}

export const UserList = (props: any) => (
  <List filters={<UserFilter />} {...props}>
    <Datagrid rowClick="edit">
      <TextField source="username" />
      <EmailField source="email" />
      <TextField source="roles" />
    </Datagrid>
  </List>
);

export const UserEdit = (props: any) => (
  <Edit title={<UserTitle />} {...props}>
    {userEditFields}
  </Edit>
);

const userEditFields = (
  <SimpleForm>
    <TextInput source="username" />
    <TextInput source="email" />
    <TextInput source="roles" />
  </SimpleForm>
);
