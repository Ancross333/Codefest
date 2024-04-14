import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { StoreModule, createFeatureSelector, createSelector } from "@ngrx/store";
import { AuthState, ConversationsState, MessagesState, userReducer } from "./user.reducers";

    export const userFeature = createFeatureSelector<AuthState>('users')
    export const selectActiveUser = createSelector(
        userFeature,
        (state: AuthState) => state.user
    )

    export const messageFeature = createFeatureSelector<MessagesState>('messages')


// Feature selector for accessing the messages state
export const selectMessagesFeature = createFeatureSelector<MessagesState>('messages');

// Selector for accessing the messages array within the messages state
export const selectAllMessages = createSelector(
  selectMessagesFeature,
  (state: MessagesState) => state.messages
);

export const selectMessagesLoading = createSelector(
  selectMessagesFeature,
  (state: MessagesState) => state.loading
);

export const selectMessagesError = createSelector(
  selectMessagesFeature,
  (state: MessagesState) => state.error
);

export const conversationsFeature = createFeatureSelector<ConversationsState>('conversations');

export const selectAllConversations = createSelector(
    conversationsFeature,
    (state: ConversationsState) => state.conversations
);

export const selectConversationsLoading = createSelector(
    conversationsFeature,
    (state: ConversationsState) => state.loading
);

export const selectConversationsError = createSelector(
    conversationsFeature,
    (state: ConversationsState) => state.error
);