import {Component, EventEmitter, Input, Output} from '@angular/core';
import {NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {CardlistVm} from "../../../models/view-models/cardlist-vm";
import {CardlistInputModel} from "../../../models/input-models/cardlist-input-model";
import {Observable} from "rxjs";
import {select, Store} from "@ngrx/store";
import {selectCardLists, selectError, selectIsLoading} from "../store/reducers";
import {AppStateInterface} from "../../../types/appState.interface";
import * as CardListsActions from "../store/actions";

@Component({
  selector: 'app-edit-cardlist',
  standalone: true,
  imports: [
    NgIf,
    FormsModule
  ],
  templateUrl: './edit-cardlist.component.html',
  styleUrl: './edit-cardlist.component.css'
})
export class EditCardlistComponent {
  @Input() cardlist?: CardlistInputModel;
  @Output() cardListFormClose = new EventEmitter();
  errors: { [key: string]: string[] } = {};
  isLoading$: Observable<boolean>;
  error$: Observable<string | null>;
  cardLists$: Observable<CardlistVm[]>;


  constructor(private store: Store<AppStateInterface>) {
    this.isLoading$ = this.store.pipe(select(selectIsLoading));
    this.error$ = this.store.pipe(select(selectError));
    this.cardLists$ = this.store.pipe(select(selectCardLists));
  }

  createCardList(cardlist: CardlistInputModel){

    this.errors = cardlist.validate();

    if (Object.keys(this.errors).length > 0) {
      return;
    }

    this.store.dispatch(CardListsActions.addCardList({ cardList: cardlist }));

    this.cancel();
  }

  updateCardList(cardlist: CardlistInputModel){

    this.errors = cardlist.validate();

    if (Object.keys(this.errors).length > 0) {
      return;
    }

    this.store.dispatch(CardListsActions.updateCardList({ cardList: cardlist }));

    this.cancel();
  }

  cancel(){
    this.cardListFormClose.emit();
    this.errors = {};
  }
}
