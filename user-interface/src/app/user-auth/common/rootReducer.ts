import { combineReducers } from "@ngrx/store";
import { userReducer } from "../ngrx/user.reducers";

export const rootReducer = combineReducers({
    user: userReducer
})