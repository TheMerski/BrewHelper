// in src/App.js
import { Route } from 'react-router';
import { Admin, Resource } from 'react-admin';
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
import { ProfileEdit } from './Profile';
import MyLayout from './Layout';

const App = () => (
  <Admin
    dashboard={Dashboard}
    authProvider={authProvider}
    dataProvider={devDataProvider}
    customRoutes={[
      <Route key="my-profile" path="/my-profile" component={ProfileEdit} />,
    ]}
    layout={MyLayout}
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
