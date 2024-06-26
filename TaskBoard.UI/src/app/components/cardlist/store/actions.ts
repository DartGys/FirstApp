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
  props<{ cardLists: CardlistVm[] }>()
);

export const addCardListFailure = createAction(
  '[CardLists] Add CardList Failure',
  props<{ error: string }>()
);

export const deleteCardList = createAction(
  '[CardLists] Delete CardList',
  props<{ Id : string | undefined, boardId: string | undefined }>()
);

export const deleteCardListSuccess = createAction(
  '[CardLists] Delete CardList Success',
  props<{ cardLists: CardlistVm[] }>()
);

export const deleteCardListFailure = createAction(
  '[CardLists] Delete CardList Failure',
  props<{ error: string }>()
);

export const updateCardList = createAction(
  '[CardLists] Update CardList',
  props<{ cardList: CardlistInputModel }>()
);

export const updateCardListSuccess = createAction(
  '[CardLists] Update CardList Success',
  props<{ cardLists: CardlistVm[] }>()
);

export const updateCardListFailure = createAction(
  '[CardLists] Update CardList Failure',
  props<{ error: string }>()
);

export const deleteCard = createAction(
  '[Card] Delete Card',
  props<{ Id?: string, boardId?: string  }>()
);

export const deleteCardSuccess = createAction(
  '[Card] Delete Card success',
  props<{ cardLists: CardlistVm[] }>()
);

export const deleteCardFailure = createAction(
  '[Card] Delete Card failure',
  props<{ error: string }>()
);
