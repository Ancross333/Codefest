import { User } from "./state-interfaces";

export interface RegisterResponse {
    userId: number;
}

export interface LoginResponse {
    user: User;
}

export interface UpdateResponse {
    userId: number;
}