import {Injectable} from "@angular/core";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import * as CardListsActions from './actions'
import {catchError, map, mergeMap, of, withLatestFrom} from "rxjs";
import {CardListService} from "../../../services/cardList.service";
import {Store} from "@ngrx/store";
import {AppStateInterface} from "../../../types/appState.interface";

@Injectable()
export class CardListsEffects {
  getCardLists$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CardListsActions.getCardLists),
      withLatestFrom(this.store.select(state => state.cardLists.boardId)),
      mergeMap(([action, boardId]) => {
        return this.cardListService.getCardListByBoard(boardId).pipe(
          map((cardLists) => CardListsActions.getCardListsSuccess({ cardLists })),
          catchError((error) =>
            of(CardListsActions.getCardListsFailure({ error: error.message }))
          )
        );
      })
    )
  );

  addCardList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CardListsActions.addCardList),
      mergeMap((action) =>
        this.cardListService.createCardList(action.cardList).pipe(
          map((cardLists) => CardListsActions.addCardListSuccess({ cardLists })),
          catchError((error) => of(CardListsActions.addCardListFailure({ error: error.message })))
        )
      )
    )
  );

  deleteCardList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CardListsActions.deleteCardList),
      withLatestFrom(this.store.select(state => ({ Id: state.cardLists.Id, boardId: state.cardLists.boardId }))),
      mergeMap(([action, ids]) => {
        return this.cardListService.deleteCardList(ids.Id, ids.boardId).pipe(
          map((cardLists) => CardListsActions.deleteCardListSuccess({ cardLists })),
          catchError((error) => of(CardListsActions.deleteCardListFailure({ error: error.message })))
        );
      })
    )
  );

  updateCardList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CardListsActions.updateCardList),
      withLatestFrom(this.store.select(state => {})),
      mergeMap(([action]) => {
        return this.cardListService.updateCardList(action.cardList).pipe(
          map((cardLists) => CardListsActions.updateCardListSuccess({ cardLists })),
          catchError((error) => of(CardListsActions.updateCardListFailure({ error: error.message })))
        );
      })
    )
  );


  constructor(private actions$: Actions, private cardListService: CardListService, private store: Store<AppStateInterface>) {}
}
