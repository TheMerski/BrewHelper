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
  Filter,
  ReferenceInput,
  SelectInput,
  AutocompleteArrayInput,
} from 'react-admin';
import { IngredientType } from '../models/Ingredient';

const typeChoices = [
  { id: IngredientType.MALT, name: 'Malt' },
  { id: IngredientType.SUGAR, name: 'Sugar' },
  { id: IngredientType.HOP, name: 'Hop' },
  { id: IngredientType.YEAST, name: 'Yeast' },
  { id: IngredientType.HERB, name: 'Herb' },
];

const IngredientTitle: React.FC<{ record?: any }> = ({ record = {} }) => {
  return <span>Ingredient: {record ? `"${record.name}"` : ''}</span>;
};

function IngredientFilter(props: any) {
  return (
    <Filter {...props}>
      <TextInput label="Search" source="Name" alwaysOn />
      <AutocompleteArrayInput source="type" choices={typeChoices} />
    </Filter>
  );
}

export const IngredientList = (props: any) => (
  <List filters={<IngredientFilter />} {...props}>
    <Datagrid rowClick="edit">
      <TextField source="name" />
      <TextField source="type" />
    </Datagrid>
  </List>
);

export const IngredientEdit = (props: any) => (
  <Edit title={<IngredientTitle />} {...props}>
    {ingredientEditForm}
  </Edit>
);

export const IngredientCreate = (props: any) => (
  <Create {...props}>{ingredientEditForm}</Create>
);

const ingredientEditForm = (
  <SimpleForm>
    <TextInput source="name" validate={[required()]} />
    <TextInput source="description" />
    <AutocompleteInput
      source="type"
      choices={typeChoices}
      validate={[required()]}
    />
  </SimpleForm>
);

