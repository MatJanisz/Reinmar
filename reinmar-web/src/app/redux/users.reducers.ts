import { ActionReducer, Action } from "@ngrx/store";
import { AppState, intitialState } from "./app.store";
import { SETUSER, LOGOUTUSER } from "./users.actions";

const INITIAL_STATE = '@ngrx/store/init';


export const userReducer: ActionReducer<AppState> =
  (state = intitialState, action: any) => {
    switch (action.type) {
      case SETUSER: {
        return {
          user: action.payload,
          authenticated: true
        }
      }
      
      case LOGOUTUSER: {
        return {
          user: action.payload,
          authenticated: false
        }
      }

      case INITIAL_STATE: {
        let user = JSON.parse(localStorage.getItem("currentUser"));
        return Object.assign({}, state, { 
          user: user? user.email : null,
          authenticated: user ? true : false
        });
      }

      default: {
        return state;
      }
    }
  };