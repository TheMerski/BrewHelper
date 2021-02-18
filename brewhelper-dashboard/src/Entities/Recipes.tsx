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
  ArrayInput,
  AutocompleteArrayInput,
  ReferenceArrayInput,
  SimpleFormIterator,
  SelectInput,
  ReferenceInput,
} from 'react-admin';
import { Recipe } from '../models/Recipe';
import { IngredientList } from './ingredients';

export const RecipeList = (props: any) => (
  <List {...props}>
    <Datagrid rowClick="edit">
      <TextField source="name" />
    </Datagrid>
  </List>
);

export const RecipeEdit = (props: any) => (
  <Edit {...props}>{recipeEditFields}</Edit>
);

const recipeEditFields = (
  <SimpleForm>
    <TextInput source="name" />
    <TextInput source="description" />
    <NumberInput source="startSG" />
    <NumberInput source="endSG" />
    <NumberInput source="yield" />
    <NumberInput source="readyAfter" />
    <NumberInput source="alcoholPercentage" />
    <NumberInput source="ibu" />
    <NumberInput source="ebc" />
    <NumberInput source="mashWater" />
    <ArrayInput source="mashSteps">
      <SimpleFormIterator>
        <TextInput source="name" label="Step name" />
        <TextInput source="description" label="Description" />
        <NumberInput source="time" label="Time (minutes)" />
        <TextInput source="temperature" label="Temperature (°C)" />
        <ArrayInput source="ingredients" label="Ingredients">
          <SimpleFormIterator>
            <ReferenceInput
              label="Ingredient"
              source="ingredient.id"
              reference="Ingredients"
            >
              <SelectInput optionText="name" />
            </ReferenceInput>
            <NumberInput source="weight" label="Weight (g)" />
          </SimpleFormIterator>
        </ArrayInput>
      </SimpleFormIterator>
    </ArrayInput>
    <NumberInput source="rinseWater" />
    <ArrayInput source="boilingSteps">
      <SimpleFormIterator>
        <TextInput source="name" label="Step name" />
        <TextInput source="description" label="Description" />
        <NumberInput source="time" label="Time (minutes)" />
        <TextInput source="temperature" label="Temperature (°C)" />
        <ArrayInput source="ingredients" label="Ingredients">
          <SimpleFormIterator>
            <ReferenceInput
              label="Ingredient"
              source="ingredient.id"
              reference="Ingredients"
            >
              <SelectInput optionText="name" />
            </ReferenceInput>
            <NumberInput source="weight" label="Weight (g)" />
          </SimpleFormIterator>
        </ArrayInput>
      </SimpleFormIterator>
    </ArrayInput>
    <ArrayInput source="yeastingSteps">
      <SimpleFormIterator>
        <TextInput source="name" label="Step name" />
        <TextInput source="description" label="Description" />
        <NumberInput source="time" label="Time (minutes)" />
        <TextInput source="temperature" label="Temperature (°C)" />
        <ArrayInput source="ingredients" label="Ingredients">
          <SimpleFormIterator>
            <ReferenceInput
              label="Ingredient"
              source="ingredient.id"
              reference="Ingredients"
            >
              <SelectInput optionText="name" />
            </ReferenceInput>
            <NumberInput source="weight" label="Weight (g)" />
          </SimpleFormIterator>
        </ArrayInput>
      </SimpleFormIterator>
    </ArrayInput>
  </SimpleForm>
);
