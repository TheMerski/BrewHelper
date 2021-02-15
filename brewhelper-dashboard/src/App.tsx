// in src/App.js
import * as React from 'react';
import { Admin, Resource, ListGuesser, EditGuesser } from 'react-admin';
import { UserList } from './user';
import { PostCreate, PostEdit, PostList } from './posts';
import PostIcon from '@material-ui/icons/Book';
import UserIcon from '@material-ui/icons/Group';
import Dashboard from './Dashboard';
import authProvider from './authProvider';
import devDataProvider from './DataProvider/devDataProvider';
import {
  IngredientCreate,
  IngredientEdit,
  IngredientList,
} from './Entities/ingredients';
import { RecipeEdit, RecipeList } from './Entities/Recipes';

const App = () => (
  <Admin
    dashboard={Dashboard}
    authProvider={authProvider}
    dataProvider={devDataProvider}
  >
    {/* <Resource
      name="posts"
      list={PostList}
      edit={PostEdit}
      create={PostCreate}
      icon={PostIcon}
    /> */}
    <Resource
      name="Ingredients"
      list={IngredientList}
      edit={IngredientEdit}
      create={IngredientCreate}
    />
    <Resource name="Recipes" list={RecipeList} edit={RecipeEdit} />
  </Admin>
);

export default App;
