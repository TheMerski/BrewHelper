import {
  List,
  Datagrid,
  TextField,
  ReferenceField,
  DateField,
  NumberField,
  DateInput,
  Edit,
  NumberInput,
  ReferenceInput,
  SelectInput,
  SimpleForm,
  TextInput,
} from 'react-admin';

export const BrewlogList = (props: any) => (
  <List {...props}>
    <Datagrid rowClick="edit">
      <ReferenceField source="recipeId" reference="Recipes">
        <TextField source="name" />
      </ReferenceField>
      <DateField source="startDate" />
      <DateField source="endDate" />
      <NumberField source="startSG" />
      <NumberField source="endSG" />
      <NumberField source="alcoholPercentage" />
      <NumberField source="yield" />
      <NumberField source="ibu" />
      <NumberField source="ebc" />
    </Datagrid>
  </List>
);

export const BrewlogEdit = (props: any) => (
  <Edit {...props}>
    <SimpleForm>
      <ReferenceInput source="recipeId" reference="Recipes">
        <SelectInput optionText="name" />
      </ReferenceInput>
      <TextInput source="notes" />
      <DateInput source="startDate" />
      <DateInput source="endDate" />
      <NumberInput source="startSG" />
      <NumberInput source="endSG" />
      <NumberInput source="alcoholPercentage" />
      <NumberInput source="yield" />
      <NumberInput source="ibu" />
      <NumberInput source="ebc" />
    </SimpleForm>
  </Edit>
);
