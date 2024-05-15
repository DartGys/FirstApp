import {Injectable} from "@angular/core";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import {Store} from "@ngrx/store";
import {AppStateInterface} from "../../../types/appState.interface";
import * as CardActions from './actions'
import {catchError, map, mergeMap, of, withLatestFrom} from "rxjs";
import {CardService} from "../../../services/card.service";

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

  constructor(private actions$: Actions, private cardService: CardService, private store: Store<AppStateInterface>) {}
}
