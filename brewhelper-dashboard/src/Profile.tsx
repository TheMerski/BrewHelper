import { bool } from 'prop-types';
import React, { useCallback, useMemo, useState } from 'react';
import {
  FileInput,
  TextInput,
  SimpleForm,
  required,
  useAuthProvider,
  useDataProvider,
  useNotify,
  SaveContextProvider,
  PasswordInput,
} from 'react-admin';
import { DataProvider } from 'react-admin';
import { validatePassword } from './validators/PasswordValidation';

export const ProfileEdit = ({ staticContext, ...props }: any) => {
  const dataProvider = useDataProvider();
  const notify = useNotify();
  const [saving, setSaving] = useState<boolean>();

  const handleSave = useCallback(
    (values: any) => {
      setSaving(true);
      dataProvider.updatePassword(
        {
          CurrentPassword: values.CurrentPassword,
          NewPassword: values.NewPassword,
        },
        {
          onSuccess: ({ data }: any) => {
            setSaving(false);
            notify('Your password has been updated', 'info', {
              _: 'Your password has been updated',
            });
          },
          onFailure: () => {
            setSaving(false);
            notify(
              'An error occured while updating your password. Please try later.',
              'warning',
              {
                _: 'An error occured while updating your password. Please try later.',
              }
            );
          },
        }
      );
    },
    [dataProvider, notify]
  );

  const saveContext = useMemo(
    () => ({
      save: handleSave,
      saving,
    }),
    [saving, handleSave]
  );

  return (
    <SaveContextProvider value={saveContext}>
      <SimpleForm save={handleSave}>
        <header>Change password</header>
        <PasswordInput source="CurrentPassword" validate={validatePassword} />
        <PasswordInput source="NewPassword" validate={validatePassword} />
      </SimpleForm>
    </SaveContextProvider>
  );
};
