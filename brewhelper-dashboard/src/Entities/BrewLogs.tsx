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
  EditProps,
  TabbedForm,
  FormTab,
  FormWithRedirect,
  SaveButton,
  DeleteButton,
  NullableBooleanInput,
  SelectArrayInput,
  Toolbar,
} from "react-admin";
import RichTextInput from "ra-input-rich-text";
import BrewDateTime from "../components/BrewDateTime";
import { Box, Grid, makeStyles, Typography } from "@material-ui/core";

const useStyles = makeStyles({
  inlineBlock: { display: "inline-flex", marginRight: "1rem" },
});

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

export const BrewlogEdit = (props: EditProps) => {
  const classes = useStyles();
  return (
    <Edit {...props}>
      <TabbedForm>
        <FormTab label="Overview">
          <ReferenceField source="recipeId" reference="Recipes">
            <TextField source="name"></TextField>
          </ReferenceField>
          <RichTextInput multiline source="notes" />
          <BrewDateTime startSource="startDate" endSource="endDate" />
          <NumberInput label="Start SG" source="startSG" formClassName={classes.inlineBlock} />
          <NumberInput label="End SG" source="endSG" formClassName={classes.inlineBlock} />
          <NumberInput label="Alcohol percentage" source="alcoholPercentage" formClassName={classes.inlineBlock} />
          <NumberInput label="Yield" source="yield" formClassName={classes.inlineBlock} />
          <NumberInput label="IBU" source="ibu" formClassName={classes.inlineBlock} />
          <NumberInput label="EBC" source="ebc" formClassName={classes.inlineBlock} />
        </FormTab>
        <FormTab label="Mashing"></FormTab>
      </TabbedForm>
    </Edit>
  );
};
