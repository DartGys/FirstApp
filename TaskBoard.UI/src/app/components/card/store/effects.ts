import {Injectable} from "@angular/core";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import {select, Store} from "@ngrx/store";
import {AppStateInterface} from "../../../types/appState.interface";
import * as CardActions from './actions'
import {catchError, map, mergeMap, of, withLatestFrom} from "rxjs";
import {CardService} from "../../../services/card.service";
import * as CardListsActions from "../../cardlist/store/actions";

@Injectable()
export class CardEffects {
  getCard$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CardActions.getCard),
      withLatestFrom(this.store.select(state => state.card.Id)),
      mergeMap(([action, Id]) => {
        return this.cardService.getCard(Id).pipe(
          map((card) => CardActions.getCardSuccess({ card })),
          catchError((error) =>
          of(CardActions.getCardFailure({error : error.message })))
        )
      })
    )
  );

  addCard$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CardActions.addCard),
      mergeMap((action) => {
        return this.cardService.createCard(action.cardInput).pipe(
          map((cardLists) => CardActions.addCardSuccess({ cardLists })),
          catchError((error) =>
            of(CardActions.addCardFailure({error : error.message })))
        )
      })
    )
  );

  updateCard$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CardActions.updateCard),
      mergeMap((action) => {
        return this.cardService.updateCard(action.card).pipe(
          map((cardLists) => CardListsActions.updateCardListSuccess({ cardLists })),
          catchError((error) => of(CardListsActions.updateCardListFailure({ error: error.message })))
        );
      })
    )
  );

  constructor(private actions$: Actions, private cardService: CardService, private store: Store<AppStateInterface>) {}
}
