import {createAction, props} from "@ngrx/store";
import {CardVmDetails} from "../../../models/view-models/card-vm-details";


export const getCard = createAction(
  '[Card] Get Card',
  props<{ Id: string | undefined }>()
);

export const getCardSuccess = createAction(
  '[Card] Get Card success',
  props<{ card: CardVmDetails }>()
);

export const getCardFailure = createAction(
  '[Card] Get Card failure',
  props<{ error: string }>()
);
