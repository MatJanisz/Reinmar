import { User } from "../model/user";


export interface State {
  app: AppState;
}

export interface AppState {
  authenticated: boolean,
  user: User
};

export const intitialState: AppState = {
    authenticated: false,
    user: {email: "", password: "", name: "", surname: ""}
};
