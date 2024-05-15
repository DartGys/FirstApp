import {createAction, props} from "@ngrx/store";
import {CardVmDetails} from "../../../models/view-models/card-vm-details";
import {CardInputModel} from "../../../models/input-models/card-input-model";
import {CardlistVm} from "../../../models/view-models/cardlist-vm";
import {CardlistInputModel} from "../../../models/input-models/cardlist-input-model";


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

export const addCard = createAction(
  '[Card] Add Card',
  props<{ cardInput: CardInputModel }>()
);

export const addCardSuccess = createAction(
  '[Card] Add Card success',
  props<{ cardLists: CardlistVm[] }>()
);

export const addCardFailure = createAction(
  '[Card] Add Card failure',
  props<{ error: string }>()
);

export const updateCard = createAction(
  '[Card] Update Card',
  props<{ card: CardInputModel }>()
);

export const updateCardSuccess = createAction(
  '[Card] Update Card Success',
  props<{ cardLists: CardlistVm[] }>()
);

export const updateCardFailure = createAction(
  '[Card] Update Failure',
  props<{ error: string }>()
);
