import { Conversation, Message, User } from "./state-interfaces";

export interface RegisterResponse {
    userId: number;
}

export interface LoginResponse {
    user: User;
}

export interface UpdateResponse {
    userId: number;
}

export interface SendMessageResponse {
    userId: number;
}

export interface GetMessagesResponse {
    messages: Message[]
}

export interface RetrieveConversationsResponse {
    conversations: Conversation[]
}

export interface SearchResultResponse {
    
}