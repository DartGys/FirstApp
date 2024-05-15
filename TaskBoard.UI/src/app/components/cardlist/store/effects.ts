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
          map((cardList) => CardListsActions.addCardListSuccess({ cardList })),
          catchError((error) => of(CardListsActions.addCardListFailure({ error: error.message })))
        )
      )
    )
  );

  constructor(private actions$: Actions, private cardListService: CardListService, private store: Store<AppStateInterface>) {}
}
