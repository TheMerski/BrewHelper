/* eslint-disable import/no-anonymous-default-export */
import * as React from 'react';
import { Card, CardContent, CardHeader } from '@material-ui/core';

export default function () {
  return (
    <Card>
      <CardHeader title="Welcome to the BrewHelper administration" />
      <CardContent>Brew some beer!</CardContent>
    </Card>
  );
}
