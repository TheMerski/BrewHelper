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
  SelectArrayInput,
  EmailField,
  required,
  minLength,
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
    <SimpleForm>
      <TextInput source="username" />
      <TextInput source="email" />
      <SelectArrayInput
        label="Roles"
        source="roles"
        choices={[
          { id: 'User', name: 'User' },
          { id: 'Admin', name: 'Admin' },
        ]}
      />
    </SimpleForm>
  </Edit>
);

const passwordValidation = (value: string) => {
  if (!/[a-z]/.test(value)) {
    return 'Password must contain at least one lowercase letter';
  }
  if (!/[A-Z]/.test(value)) {
    return 'Password must contain at least one uppercase letter';
  }
  if (!/[0-9]/.test(value)) {
    return 'Password must contain at least one number';
  }
  if (!/[^a-zA-Z\d\s:]/.test(value)) {
    return 'Password must contain at least one non alphanumeric character';
  }
  return undefined;
};
const validatePassword = [required(), minLength(6), passwordValidation];

export const UserCreate = (props: any) => (
  <Create {...props}>
    <SimpleForm>
      <TextInput source="username" />
      <TextInput source="email" />
      <SelectArrayInput
        label="Roles"
        source="roles"
        choices={[
          { id: 'User', name: 'User' },
          { id: 'Admin', name: 'Admin' },
        ]}
      />
      <TextInput source="password" validate={validatePassword} />
    </SimpleForm>
  </Create>
);
