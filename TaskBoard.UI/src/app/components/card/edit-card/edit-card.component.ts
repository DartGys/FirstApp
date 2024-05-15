import {Component, EventEmitter, Input, OnChanges, Output, SimpleChanges} from '@angular/core';
import {CardService} from "../../../services/card.service";
import {CardInputModel} from "../../../models/input-models/card-input-model";
import {CardlistVm} from "../../../models/view-models/cardlist-vm";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {PriorityVm} from "../../../models/view-models/priority-vm";
import {CardlistVmList} from "../../../models/view-models/cardlist-vm-list";
import {CardListService} from "../../../services/cardList.service";
import {PriorityService} from "../../../services/priority.service";
import {select, Store} from "@ngrx/store";
import {AppStateInterface} from "../../../types/appState.interface";
import {selectCardLists, selectError, selectIsLoading} from "../store/reducers";
import {Observable} from "rxjs";
import * as CardActions from "../store/actions";

@Component({
  selector: 'app-edit-card',
  standalone: true,
  imports: [
    FormsModule,
    NgIf,
    NgForOf

  ],
  templateUrl: './edit-card.component.html',
  styleUrl: './edit-card.component.css'
})
export class EditCardComponent  implements OnChanges{
  @Input() card?: CardInputModel;
  @Output() cardlistsUpdated = new EventEmitter<CardlistVm[]>();
  @Output() cardFormClose = new EventEmitter();
  cardlists: CardlistVmList[] = [];
  priorities: PriorityVm[] = [];
  errors: { [key: string]: string[] } = {};
  isLoading$: Observable<boolean>;
  error$: Observable<string | null>;
  cardLists$: Observable<CardlistVm[]>

  constructor(private cardService: CardService, private cardListService: CardListService,
              private priorityService: PriorityService, private store: Store<AppStateInterface>) {
  this.isLoading$ = this.store.pipe(select(selectIsLoading));
  this.error$ = this.store.pipe(select(selectError));
  this.cardLists$ = this.store.pipe(select(selectCardLists));
}
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['card'] && !changes['card'].firstChange && this.card) {
      this.loadData();
    }
  }

  loadData(){
    this.loadPriorities();
    this.loadCardlists();
  }

  loadCardlists() {
    this.cardListService.getCardListsListByBoard(this.card?.boardId)
      .subscribe((data: CardlistVmList[]) => {
        this.cardlists = data;
      });
  }

  loadPriorities() {
    this.priorityService.getPriorities()
      .subscribe((data: PriorityVm[]) => {
        this.priorities = data;
      });
  }

  cancel() {
    this.cardFormClose.emit(this.cardLists$);
    this.errors = {};
  }

  createCard(card: CardInputModel){
    this.errors = card.validate();

    if (Object.keys(this.errors).length > 0) {
      return;
    }

    this.store.dispatch(CardActions.addCard({cardInput: card}))

    this.cancel();
  }

  updateCard(card: CardInputModel){

    this.errors = card.validate();

    if (Object.keys(this.errors).length > 0) {
      return;
    }

    this.store.dispatch(CardActions.updateCard({card: card}))

    this.cancel();
  }
}
