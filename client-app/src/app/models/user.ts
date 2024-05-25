export interface User {
  firstName: string;
  lastName: string;
  token: string;
  username: string;
  image?: any;
}

export interface UserFormValues {
  email: string;
  password: string;
  firstName?: string;
  lastName?: string;
  username?: string;
}
