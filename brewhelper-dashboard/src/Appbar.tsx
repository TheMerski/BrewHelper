import React from 'react';
import { AppBar } from 'react-admin';
import MyUserMenu from './Menu';

function MyAppBar(props: any) {
  return <AppBar {...props} userMenu={<MyUserMenu />} />;
}
export default MyAppBar;
