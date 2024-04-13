import { createReducer, on } from '@ngrx/store';
import { LoginActions, RegisterActions } from './user.actions'
import { User } from '../common/state-interfaces';

export interface AuthState {
  user: User | null;
  loginError: Error | null;
  registerSuccess: boolean;
  registerMessage: string;
  registerError: Error | null;
}

export const initialAuthState: AuthState = {
  user: null,
  loginError: null,
  registerSuccess: false,
  registerMessage: '',
  registerError: null,
};

export const userReducer = createReducer(
  initialAuthState,
  on(LoginActions.loginSuccess, (state, { user }) => ({
    ...state,
    user: user,
    loginError: null,
  })),
  on(LoginActions.loginFailure, (state, { error }) => ({
    ...state,
    loginError: error,
  })),
  on(RegisterActions.registerSuccess, (state, { succeeded, errorMessage }) => ({
    ...state,
    registerSuccess: succeeded,
    registerMessage: errorMessage,
    registerError: null,
  })),
  on(RegisterActions.registerFailure, (state, { succeeded, errorMessage }) => ({
    ...state,
    registerSuccess: succeeded,
    registerMessage: errorMessage,
  })),
);
