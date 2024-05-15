import {Component, EventEmitter, Input, OnChanges, Output, SimpleChanges} from '@angular/core';
import {CardVmDetails} from "../../models/view-models/card-vm-details";
import {FormsModule} from "@angular/forms";
import {AsyncPipe, DatePipe, NgForOf, NgIf} from "@angular/common";
import {CardService} from "../../services/card.service";
import {Observable, of} from "rxjs";
import {select, Store} from "@ngrx/store";
import {AppStateInterface} from "../../types/appState.interface";
import * as CardActions from "./store/actions";
import {selectCard, selectError, selectIsLoading} from "./store/reducers";

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [
    FormsModule,
    NgIf,
    DatePipe,
    NgForOf,
    AsyncPipe
  ],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent implements OnChanges{
  @Output() cardClose = new EventEmitter();
  @Input() cardId?: string;
  isLoading$: Observable<boolean>;
  error$: Observable<string | null>;
  card$: Observable<CardVmDetails | undefined>;

  constructor(private cardService: CardService, private store: Store<AppStateInterface>) {
  this.isLoading$ = this.store.pipe(select(selectIsLoading));
  this.error$ = this.store.pipe(select(selectError));
  this.card$ = this.store.pipe(select(selectCard));
}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['cardId'] && !changes['cardId'].firstChange && this.cardId) {
      this.loadCardVm();
    }
  }

  loadCardVm(){
    if(this.cardId) {
      this.store.dispatch(CardActions.getCard({Id: this.cardId}));
    }
  }

  cancel(){
    this.cardClose.emit();
  }
}
