import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { StoreModule, createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthState, userReducer } from "./user.reducers";

    export const userFeature = createFeatureSelector<AuthState>('users')
    export const selectActiveUser = createSelector(
        userFeature,
        (state: AuthState) => state.user
    )
