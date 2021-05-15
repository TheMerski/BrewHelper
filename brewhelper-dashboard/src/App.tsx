// in src/App.js
import * as React from 'react';
import { Admin, Resource, ListGuesser, EditGuesser } from 'react-admin';
import { PostCreate, PostEdit, PostList } from './posts';
import PostIcon from '@material-ui/icons/Book';
import UserIcon from '@material-ui/icons/Group';
import Dashboard from './Dashboard';
import authProvider from './DataProvider/authProvider';
import devDataProvider from './DataProvider/BrewHelperDataProvider';
import {
  IngredientCreate,
  IngredientEdit,
  IngredientList,
} from './Entities/ingredients';
import { RecipeCreate, RecipeEdit, RecipeList } from './Entities/Recipes';
import { UserCreate, UserEdit, UserList } from './Entities/Users';

const App = () => (
  <Admin
    dashboard={Dashboard}
    authProvider={authProvider}
    dataProvider={devDataProvider}
  >
    {(permissions: string[]) => [
      <Resource
        name="Ingredients"
        list={IngredientList}
        edit={IngredientEdit}
        create={IngredientCreate}
      />,
      <Resource
        name="Recipes"
        list={RecipeList}
        edit={RecipeEdit}
        create={RecipeCreate}
      />,
      permissions.includes('Admin') ? (
        <Resource
          name="Users"
          list={UserList}
          edit={UserEdit}
          create={UserCreate}
        />
      ) : null,
    ]}
  </Admin>
);

export default App;

/* <Resource
      name="posts"
      list={PostList}
      edit={PostEdit}
      create={PostCreate}
      icon={PostIcon}
    /> */
