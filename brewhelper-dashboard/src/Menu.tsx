import React from 'react';
import { UserMenu, MenuItemLink } from 'react-admin';
import SettingsIcon from '@material-ui/icons/Settings';

function MyUserMenu(props: any) {
  return (
    <UserMenu {...props}>
      <MenuItemLink
        {...props}
        to="/my-profile"
        primaryText="My Profile"
        leftIcon={<SettingsIcon />}
      />
    </UserMenu>
  );
}

export default MyUserMenu;
