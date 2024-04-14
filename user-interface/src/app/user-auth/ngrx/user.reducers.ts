import { createReducer, on } from '@ngrx/store';
import { GetConversationActions, GetMessageActions, LoginActions, RegisterActions, SendMessageActions } from './user.actions'
import { Conversation, User } from '../common/state-interfaces';

export interface AuthState {
  user: User | null;
  loginError: Error | null;
  registerSuccess: boolean;
  registerMessage: string;
  registerError: Error | null;
}

export const initialAuthState: AuthState = {
//   user: {id: 1, email: "email", firstName: "", lastName: "", accountType: 0, zipCode: 0, companyName: null}
user: null,
  loginError: null,
  registerSuccess: false,
  registerMessage: '',
  registerError: null,
};

export interface MessagesState {
    messages: any[];  
    error: Error | null;
    loading: boolean;
  }
  
  export const initialMessagesState: MessagesState = {
    messages: [],
    error: null,
    loading: false,
  };

  export interface ConversationsState {
    conversations: Conversation[]; 
    error: Error | null;
    loading: boolean;
  }
  
  export const initialConversationsState: ConversationsState = {
      conversations: [],
      error: null,
      loading: false,
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

export const messagesReducer = createReducer(
    initialMessagesState,
    on(GetMessageActions.getMessages, state => ({
      ...state,
      loading: true,
      error: null
    })),
    on(GetMessageActions.getMessagesSuccess, (state, { messages }) => ({
      ...state,
      messages: messages,
      loading: false,
      error: null
    })),
    on(GetMessageActions.getMessagesError, (state, { error }) => ({
      ...state,
      loading: false,
      error: error
    })),
    on(SendMessageActions.sendMessage, state => ({
        ...state,
        loading: true,
        error: null
      })),
    on(SendMessageActions.sendMessageSuccess, (state, { message }) => {
        // Update the messages array with the new message
        return {
          ...state,
          messages: [...state.messages, message],
          loading: false,
          error: null
        };
    }),
    on(SendMessageActions.sendMessageError, (state, { error }) => ({
        ...state,
        loading: false,
        error: error
    }))
);


  export const conversationsReducer = createReducer(
    initialConversationsState,
    on(GetConversationActions.getConversations, state => ({
      ...state,
      loading: true,
      error: null
    })),
    on(GetConversationActions.getConversationsSuccess, (state, { conversations }) => ({
      ...state,
      conversations: conversations,
      loading: false,
      error: null
    })),
    on(GetConversationActions.getConversationsError, (state, { error }) => ({
      ...state,
      loading: false,
      error: error
    }))
  );
