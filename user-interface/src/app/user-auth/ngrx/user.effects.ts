import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { of } from "rxjs";
import { catchError, exhaustMap, map } from "rxjs/operators";
import { UserService } from "./user.service";
import { LoginActions, RegisterActions } from "./user.actions";
import { LoginResponse, RegisterResponse } from "../common/api-responses";

@Injectable()
export class UserEffects {
    constructor(private actions$: Actions, private userService: UserService) {}

    registerUser$ = createEffect(() => this.actions$.pipe(
        ofType(RegisterActions.register),
        exhaustMap(action => 
            this.userService.register(
                action.email, 
                action.password, 
                action.companyName,
                action.firstName,
                action.lastName,
                action.zipCode,
                action.accountType
            ).pipe(
                map((response: RegisterResponse) => {
                
                const success = true;
                return RegisterActions.registerSuccess({succeeded: success, errorMessage: "No Error"});
                    
                }),
                catchError((error) => 
                    of(RegisterActions.registerFailure(error))
                )
            )
        )
    ));

    login$ = createEffect(() => this.actions$.pipe(
        ofType(LoginActions.login),
        exhaustMap(action => 
            this.userService.login(action.email, action.password)
            .pipe(
                map((response: LoginResponse) => {
                    return LoginActions.loginSuccess({user: response.user})
                })
            )
        )
    ))
}
