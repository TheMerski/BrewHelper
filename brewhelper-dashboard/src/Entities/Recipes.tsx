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
} from 'react-admin';

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


const recipeEditFields = (
  <SimpleForm>
    <TextInput source="name" required />
    <TextInput multiline fullWidth source="description" />
    <>
      <NumberInput source="alcoholPercentage" />
      <NumberInput source="readyAfter" label="Ready after (days)"/>
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
    {recipeStepEditFields('mashing', 'minutes')}
    {recipeStepEditFields('boiling', 'minutes')}
    {recipeStepEditFields('yeasting', 'days')}
  </SimpleForm>
);

function recipeStepEditFields(source: string, time: string) {
	return (
    <>
      <h3>{`${source} step`}</h3>
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
          >
            <AutocompleteInput optionText="name" />
          </ReferenceInput>
          <NumberInput source="weight" label="Weight (g)" />
          <NumberInput source="addAfter" label={`Add after (${time})`} />
        </SimpleFormIterator>
      </ArrayInput>
    </>
  );
}
