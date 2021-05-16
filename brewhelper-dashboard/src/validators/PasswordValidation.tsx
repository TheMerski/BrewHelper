import { minLength, required } from 'react-admin';

const passwordValidation = (value: string) => {
  if (!/[a-z]/.test(value)) {
    return 'Password must contain at least one lowercase letter';
  }
  if (!/[A-Z]/.test(value)) {
    return 'Password must contain at least one uppercase letter';
  }
  if (!/[0-9]/.test(value)) {
    return 'Password must contain at least one number';
  }
  if (!/[^a-zA-Z\d\s:]/.test(value)) {
    return 'Password must contain at least one non alphanumeric character';
  }
  return undefined;
};
export const validatePassword = [required(), minLength(6), passwordValidation];
