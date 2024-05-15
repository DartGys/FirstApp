import {CardListStateInterface} from "../types/CardListStateInterface";
import {createFeature, createReducer, on} from "@ngrx/store";
import * as CardListsActions from './actions'

export const initialState: CardListStateInterface = {
  isLoading: false,
  cardLists: [],
  error: null,
  boardId: undefined
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
      cardLists: action.cardList,
    })),
    on(CardListsActions.addCardListFailure, (state, action) => ({
      ...state,
      isLoading: false,
      error: action.error,
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
