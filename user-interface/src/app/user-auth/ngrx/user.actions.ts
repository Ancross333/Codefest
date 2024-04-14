import { createAction, createActionGroup, props } from "@ngrx/store";
import { Conversation, Message, User } from "../common/state-interfaces";

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
            values: number[];
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

export const SendMessageActions = createActionGroup({
    source: "[Message] Send Message",
    events: {
        sendMessage: props<{
            senderId: number;
            receiverId: number;
            createdAt: Date;
            content: string;
        }>(),

        sendMessageError: props<{
            error: Error
        }>(),

        sendMessageSuccess: props<{
            message: Message;
        }>()
    }
});

export const GetMessageActions = createActionGroup({
    source: "[Message] Get Messages",
    events: {
        getMessages: props<{
            senderId: number;
            receiverId: number;
        }>(),

        getMessagesSuccess: props<{
            messages: Message[]
        }>(),

        getMessagesError: props<{
            error: Error
        }>()
    }
})

export const GetConversationActions = createActionGroup({
    source: "[Message] Get Messages",
    events: {
        getConversations: props<{
            userId: number
        }>(),

        getConversationsSuccess: props<{
            conversations: Conversation[]
        }>(),

        getConversationsError: props<{
            error: Error
        }>()
    }
})