import * as React from 'react';
import {
  List,
  Datagrid,
  TextField,
  Edit,
  SimpleForm,
  TextInput,
  AutocompleteInput,
  Create,
  required,
} from 'react-admin';

const IngredientTitle: React.FC<{ record?: any }> = ({ record = {} }) => {
  return <span>Ingredient {record ? `"${record.name}"` : ''}</span>;
};

export const IngredientList = (props: any) => (
  <List {...props}>
    <Datagrid rowClick="edit">
      <TextField source="name" />
      <TextField source="type" />
    </Datagrid>
  </List>
);

export const IngredientEdit = (props: any) => (
  <Edit title={<IngredientTitle />} {...props}>
    <SimpleForm>
      <TextInput source="name" validate={[required()]} />
      <TextInput source="description" />
      <AutocompleteInput
        source="type"
        choices={[
          { id: 'Malt', name: 'Malt' },
          { id: 'Sugar', name: 'Sugar' },
          { id: 'Hop', name: 'Hop' },
          { id: 'Yeast', name: 'Yeast' },
          { id: 'Herb ', name: 'Herb' },
        ]}
        validate={[required()]}
      />
    </SimpleForm>
  </Edit>
);

export const IngredientCreate = (props: any) => (
  <Create {...props}>
    <SimpleForm>
      <TextInput source="name" validate={[required()]} />
      <TextInput source="description" />
      <AutocompleteInput
        source="type"
        choices={[
          { id: 'Malt', name: 'Malt' },
          { id: 'Sugar', name: 'Sugar' },
          { id: 'Hop', name: 'Hop' },
          { id: 'Yeast', name: 'Yeast' },
          { id: 'Herb ', name: 'Herb' },
        ]}
        validate={[required()]}
      />
    </SimpleForm>
  </Create>
);
