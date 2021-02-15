import React from 'react';
import {
  List,
  Datagrid,
  TextField,
  NumberField,
  Edit,
  NumberInput,
  SimpleForm,
  TextInput,
  RichTextField,
} from 'react-admin';

export const RecipeList = (props: any) => (
  <List {...props}>
    <Datagrid rowClick="edit">
      <TextField source="name" />
    </Datagrid>
  </List>
);

export const RecipeEdit = (props: any) => (
  <Edit {...props}>
    <SimpleForm>
      <TextInput source="name" />
      <TextInput multiline source="description" />
      <NumberInput source="startSG" />
      <NumberInput source="endSG" />
      <NumberInput source="yield" />
      <NumberInput source="readyAfter" />
      <NumberInput source="alcoholPercentage" />
      <NumberInput source="ibu" />
      <NumberInput source="ebc" />
      <NumberInput source="mashWater" />
      <TextInput source="mashIngredients" />
      <TextInput source="mashSteps" />
      <NumberInput source="rinseWater" />
      <TextInput source="boilingSteps" />
      <TextInput source="yeastingSteps" />
    </SimpleForm>
  </Edit>
);
