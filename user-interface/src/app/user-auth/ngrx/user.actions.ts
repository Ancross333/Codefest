import { createAction, createActionGroup, props } from "@ngrx/store";
import { User } from "../common/state-interfaces";

export const LoginActions = createActionGroup({
    source: "[Login] Login",
    events: {
        login: props<{
            email: string,
            password: string
        }>(),

        loginSuccess: props<{
            user: User
        }>(),

        loginFailure: props<{
            error: Error
        }>()
    }
})

export const RegisterActions = createActionGroup({
    source: '[Register] Register',
    events: {
        register: props<{
            email: string;
            password: string;
            companyName: string | null;
            firstName: string;
            lastName: string,
            zipCode: number;
            accountType: number;
        }>(),

        registerSuccess: props<{
            succeeded: boolean;
            errorMessage: string;
        }>(),

        registerFailure: props<{
            succeeded: boolean;
            errorMessage: string;
        }>(),

        registerError: props<{
            error: Error;
        }>
    }
}

)