import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { of } from "rxjs";
import { catchError, exhaustMap, map } from "rxjs/operators";
import { GetConversationActions, GetMessageActions, LoginActions, RegisterActions, SendMessageActions } from "./user.actions";
import { GetMessagesResponse, LoginResponse, RegisterResponse, SendMessageResponse } from "../common/api-responses";
import { UserService } from "./user.service";
import { MessageService } from "./message.service";

@Injectable()
export class UserEffects {
    constructor(private actions$: Actions, private userService: UserService, private messageService: MessageService) {}

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
                action.accountType,
                action.values
            ).pipe(
                map((response: RegisterResponse) => {
                    console.log(response)
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

    sendMessage$ = createEffect(() => this.actions$.pipe(
        ofType(SendMessageActions.sendMessage),
        exhaustMap((action: any) => 
            this.messageService.sendMessage(action.senderId, action.receiverId, action.createdAt, action.content)
            .pipe(
                map((response: SendMessageResponse) => {
                    return SendMessageActions.sendMessageSuccess({message: {
                        senderId: action.senderId, receiverId: action.receiverId, createdAt: action.createdAt, content: action.content,
                        id: 0
                    }})
                }),
                catchError((error) => of(SendMessageActions.sendMessageError({error})))
            )
        )
    ));

    getMessages$ = createEffect(() => this.actions$.pipe(
        ofType(GetMessageActions.getMessages),
        exhaustMap((action: any) => 
            this.messageService.retrieveMessages(action.senderId, action.receiverId).pipe(
                map((response: GetMessagesResponse) => {
                    console.log(response);
                    return GetMessageActions.getMessagesSuccess({messages: response.messages});
                }),
                catchError((error) => of(GetMessageActions.getMessagesError({error: error})))
            )
        )
    ));
    
    getConversations$ = createEffect(() => this.actions$.pipe(
        ofType(GetConversationActions.getConversations),
        exhaustMap((action) =>
            this.messageService.retrieveConversations(action.userId).pipe(
                map((response) => GetConversationActions.getConversationsSuccess({ conversations: response.conversations })),
                catchError((error) => of(GetConversationActions.getConversationsError({ error: error })))
            )
        )
    ));
    
}
