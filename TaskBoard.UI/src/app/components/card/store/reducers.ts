import {CardStateInterface} from "../types/cardState.interface";
import {createFeature, createReducer, on} from "@ngrx/store";
import * as CardActions from './actions'


export const initialState: CardStateInterface = {
  isLoading: false,
  cardLists: [],
  card: undefined,
  cardInput: undefined,
  error: null,
  Id: undefined,
};

const cardFeature = createFeature({
  name: 'card',
  reducer: createReducer(
    initialState,
    on(CardActions.getCard, (state, action) => ({ ...state, isLoading: true, Id: action.Id})),
    on(CardActions.getCardSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      card: action.card
    })),
    on(CardActions.getCardFailure, (state, action) => ({
      ...state,
      isLoading: false,
      error: action.error
    }))
  )
});

export const {
  name: cardFeatureKey,
  reducer: cardReducer,
  selectError,
  selectIsLoading,
  selectCard,
} = cardFeature;
