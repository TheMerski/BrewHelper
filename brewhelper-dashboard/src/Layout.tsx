import React from 'react';
import { Layout } from 'react-admin';
import MyAppBar from './Appbar';

function MyLayout(props: any) {
  return <Layout {...props} appBar={MyAppBar} />;
}

export default MyLayout;
