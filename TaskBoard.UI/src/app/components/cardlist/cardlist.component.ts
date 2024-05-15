import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {CardlistVm, CardVmList} from "../../models/view-models/cardlist-vm";
import {AsyncPipe, DatePipe, NgForOf, NgIf, NgOptimizedImage} from "@angular/common";
import {EditCardlistComponent} from "./edit-cardlist/edit-cardlist.component";
import {CardlistInputModel} from "../../models/input-models/cardlist-input-model";
import {CardInputModel} from "../../models/input-models/card-input-model";
import {CardService} from "../../services/card.service";
import {EditCardComponent} from "../card/edit-card/edit-card.component";
import {FormsModule} from "@angular/forms";
import {CardComponent} from "../card/card.component";
import {Observable, withLatestFrom} from "rxjs";
import {select, Store} from "@ngrx/store";
import {AppStateInterface} from "../../types/appState.interface";
import {selectCardLists, selectError, selectIsLoading} from "./store/reducers";
import * as CardListsActions from './store/actions'
import * as CardActions from '../card/store/actions'
@Component({
  selector: 'app-cardlist',
  standalone: true,
  imports: [
    NgForOf,
    DatePipe,
    NgIf,
    EditCardlistComponent,
    NgOptimizedImage,
    EditCardComponent,
    FormsModule,
    CardComponent,
    AsyncPipe
  ],
  templateUrl: './cardlist.component.html',
  styleUrl: './cardlist.component.css'
})
export class CardlistComponent implements OnChanges{
  isLoading$: Observable<boolean>;
  error$: Observable<string | null>;
  cardLists$: Observable<CardlistVm[]>;
  cardLists?: CardlistVm[] = [];
  @Input() boardId?: string;
  @Input() boardName?: string;
  @Output() goToBoards = new EventEmitter();
  cardlistToEdit?: CardlistInputModel;
  cardToEdit?: CardInputModel;
  cardIdToShow?: string;

  constructor(private cardService: CardService, private store: Store<AppStateInterface>) {
    this.isLoading$ = this.store.pipe(select(selectIsLoading));
    this.error$ = this.store.pipe(select(selectError));
    this.cardLists$ = this.store.pipe(select(selectCardLists));
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['boardId'] && !changes['boardId'].firstChange && this.boardId) {
        this.loadCardLists();
    }
  }

  loadCardLists() {
    this.store.dispatch(CardListsActions.getCardLists({ boardId: this.boardId }));
  }

  closeCardForm(cardList: Observable<CardlistVm[]>){
    this.cardLists$ = cardList;
    this.cardToEdit = undefined;
  }

  closeCardListForm(){
    this.cardlistToEdit = undefined;
  }

  initNewCardList(){
    this.cardlistToEdit = Object.assign(new CardlistInputModel(), {
      boardId: this.boardId
    })
  }

  editCardList(cardlist: CardlistVm){
    this.cardlistToEdit = Object.assign(new CardlistInputModel(), {
      id: cardlist.id,
      name: cardlist.name,
      boardId: this.boardId
    })
  }

  initNewCard(listId: string){
    this.cardToEdit =  Object.assign(new CardInputModel(), {
      cardListId: listId,
      boardId: this.boardId
    });
  }

  editCard(card: CardVmList){
    this.cardToEdit =  Object.assign(new CardInputModel(), {
      id: card.id,
      name: card.name,
      description: card.description,
      dueDate: card.dueDate,
      priorityId: card.priorityId,
      cardListId: card.cardListId,
      boardId: this.boardId
    });
  }

  showCard(cardId:string){
    this.cardIdToShow = cardId;
  }

  closeCard(){
    this.cardIdToShow = undefined;
  }

  deleteCardList(id: string){
    this.store.dispatch(CardListsActions.deleteCardList({Id: id, boardId: this.boardId }));
  }

  deleteCard(id: string){
    this.store.dispatch(CardListsActions.deleteCard({Id: id, boardId: this.boardId}));
  }

  selectedListId= '';

  moveCardTo(cardId: string){
    this.cardService.updateCardList(cardId, this.selectedListId, this.boardId).subscribe(
      (response) => {
        this.cardLists = response;
      },
    );
    this.selectedListId = ''
  }

  backToBoards(){
    this.goToBoards.emit();
  }
}
