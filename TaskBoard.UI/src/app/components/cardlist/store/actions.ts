import {createAction, props} from "@ngrx/store";
import {CardlistVm} from "../../../models/view-models/cardlist-vm";
import {CardlistInputModel} from "../../../models/input-models/cardlist-input-model";


export const getCardLists = createAction(
  '[CardLists] Get CardLists',
  props<{ boardId: string | undefined }>()
);

export const getCardListsSuccess = createAction(
  '[CardLists] Get CardLists success',
  props<{ cardLists: CardlistVm[] }>()
);

export const getCardListsFailure = createAction(
  '[CardLists] Get CardLists failure',
  props<{ error: string }>()
);

export const addCardList = createAction(
  '[CardLists] Add CardList',
  props<{ cardList: CardlistInputModel }>()
);

export const addCardListSuccess = createAction(
  '[CardLists] Add CardList Success',
  props<{ cardList: CardlistVm[] }>()
);

export const addCardListFailure = createAction(
  '[CardLists] Add CardList Failure',
  props<{ error: string }>()
);
