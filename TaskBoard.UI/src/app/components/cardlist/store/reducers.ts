import {CardListStateInterface} from "../types/cardListState.interface";
import {createFeature, createReducer, on} from "@ngrx/store";
import * as CardListsActions from './actions'
import * as CardActions from "../../card/store/actions";

export const initialState: CardListStateInterface = {
  isLoading: false,
  cardLists: [],
  cardList: undefined,
  error: null,
  boardId: undefined,
  Id: undefined,
};

const cardListsFeature = createFeature({
  name: 'cardLists',
  reducer: createReducer(
    initialState,
    on(CardListsActions.getCardLists, (state, action) => ({ ...state, isLoading: true, boardId: action.boardId })),
    on(CardListsActions.getCardListsSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      cardLists: action.cardLists,
    })),
    on(CardListsActions.getCardListsFailure, (state, action) => ({
      ...state,
      isLoading: false,
      error: action.error,
    })),
    on(CardListsActions.addCardList, (state) => ({ ...state, isLoading: true })),
    on(CardListsActions.addCardListSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      cardLists: action.cardLists,
    })),
    on(CardListsActions.addCardListFailure, (state, action) => ({
      ...state,
      isLoading: false,
      error: action.error,
    })),
    on(CardListsActions.deleteCardList, (state, action) => ({ ...state, isLoading: true, Id: action.Id, boardId: action.boardId })),
    on(CardListsActions.deleteCardListSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      cardLists: action.cardLists,
    })),
    on(CardListsActions.deleteCardListFailure, (state, action) => ({
      ...state,
      isLoading: false,
      error: action.error,
    })),
    on(CardListsActions.updateCardList, (state, action) => ({ ...state, isLoading: true, cardList: action.cardList})),
    on(CardListsActions.updateCardListSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      cardLists: action.cardLists,
    })),
    on(CardListsActions.updateCardListFailure, (state, action) => ({
      ...state,
      isLoading: false,
      error: action.error,
    })),
    on(CardListsActions.deleteCard, (state, action) => ({ ...state, isLoading: true, Id: action.Id, boardId: action.boardId})),
    on(CardListsActions.deleteCardSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      cardLists: action.cardLists
    })),
    on(CardListsActions.deleteCardFailure, (state, action) => ({
      ...state,
      isLoading: false,
      error: action.error
    }))
  ),
});

export const {
  name: cardListsFeatureKey,
  reducer: cardListsReducer,
  selectError,
  selectIsLoading,
  selectCardLists,
} = cardListsFeature;
