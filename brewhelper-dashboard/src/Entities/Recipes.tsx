import React from 'react';
import {
  List,
  Datagrid,
  TextField,
  Edit,
  NumberInput,
  TextInput,
  ArrayInput,
  SimpleFormIterator,
  ReferenceInput,
  Create,
  Filter,
  AutocompleteInput,
  TabbedForm,
  FormTab,
} from 'react-admin';
import { Ingredient } from '../models/Ingredient';

const RecipeTitle: React.FC<{ record?: any }> = ({ record = {} }) => {
  return <span>Recipe: {record ? `"${record.name}"` : ''}</span>;
};

function RecipeFilter(props: any) {
  return (
    <Filter {...props}>
      <TextInput label="Search" source="Name" alwaysOn />
    </Filter>
  );
}

export const RecipeList = (props: any) => (
  <List filters={<RecipeFilter />} {...props}>
    <Datagrid rowClick="edit">
      <TextField source="name" />
    </Datagrid>
  </List>
);

export const RecipeEdit = (props: any) => (
  <Edit title={<RecipeTitle />} {...props}>
    {recipeEditFields}
  </Edit>
);

export const RecipeCreate = (props: any) => (
	<Create {...props}>{recipeEditFields}</Create>
);

const IngredientFilter = (filter: string) => {
  return { Name: filter };
};

const IngredientOptionText = (choice: any) => (
  <span style={{ color: choice.record.inStock > 0 ? 'black' : 'grey' }}>
    {choice.record.name} ({choice.record.inStock} g)
  </span>
);

const IngredientOptionInputText = (choice: Ingredient | any) =>
  `${choice.name} (${choice.inStock} g)`;

const IngredientOptionOptions = (choice: Ingredient | any) => {
  return { color: 'secondary' };
};

const IngredientOptionMatch = (filter: string, choice: any) => {
  return true;
};

const recipeEditFields = (
  <TabbedForm>
    <FormTab label="Information">
      <TextInput source="name" required />
      <TextInput multiline fullWidth source="description" />
      <>
        <NumberInput source="alcoholPercentage" />
        <NumberInput source="readyAfter" label="Ready after (days)" />
        <NumberInput source="yield" />
      </>
      <>
        <NumberInput source="ibu" />
        <NumberInput source="ebc" />
      </>
      <>
        <NumberInput source="startSG" />
        <NumberInput source="endSG" />
      </>
      <>
        <NumberInput source="mashWater" />
        <NumberInput source="rinseWater" />
      </>
    </FormTab>
    <FormTab label="Mashing">{recipeStepEditFields('mashing', 'minutes')}</FormTab>
    <FormTab label="Boiling">{recipeStepEditFields('boiling', 'minutes')}</FormTab>
    <FormTab label="Yeasting">{recipeStepEditFields('yeasting', 'days')}</FormTab>
  </TabbedForm>
);

function recipeStepEditFields(source: string, time: string) {
	return (
    <>
      {/* <h3>{`${source} step`}</h3> */}
      <TextInput
        multiline
        source={`${source}.description`}
        label="Description"
        fullWidth
      />
      <NumberInput source={`${source}.time`} label={`Time (${time})`} />
      <TextInput source={`${source}.temperature`} label="Temperature (°C)" />
      <ArrayInput source={`${source}.ingredients`} label="Ingredients">
        <SimpleFormIterator>
          <ReferenceInput
            label="Ingredient"
            source="ingredientId"
            reference="Ingredients"
            filterToQuery={IngredientFilter}
          >
            <AutocompleteInput
              optionText={<IngredientOptionText />}
              inputText={IngredientOptionInputText}
              matchSuggestion={IngredientOptionMatch}
            />
          </ReferenceInput>
          <NumberInput source="weight" label="Weight (g)" required  />
          <NumberInput source="addAfter" label={`Add after (${time})`} defaultValue='0' required/>
        </SimpleFormIterator>
      </ArrayInput>
    </>
  );
}
