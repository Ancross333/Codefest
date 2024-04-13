import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideState, provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { rootReducer } from './user-auth/common/rootReducer';
import { UserEffects } from './user-auth/ngrx/user.effects';
import { provideHttpClient } from '@angular/common/http';
import { userReducer } from './user-auth/ngrx/user.reducers';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideStore({reducer: rootReducer}), provideEffects(UserEffects), provideHttpClient(), provideAnimationsAsync(), provideState({name: 'users', reducer: userReducer}) ]
};
