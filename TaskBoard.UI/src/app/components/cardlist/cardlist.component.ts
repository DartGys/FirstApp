import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {CardlistVm, CardVmList} from "../../models/view-models/cardlist-vm";
import {CardListService} from "../../services/cardList.service";
import {DatePipe, NgForOf, NgIf, NgOptimizedImage} from "@angular/common";
import {EditCardlistComponent} from "./edit-cardlist/edit-cardlist.component";
import {CardlistInputModel} from "../../models/input-models/cardlist-input-model";
import {CardInputModel} from "../../models/input-models/card-input-model";
import {CardService} from "../../services/card.service";
import {EditCardComponent} from "../card/edit-card/edit-card.component";
import {FormsModule} from "@angular/forms";
import {CardComponent} from "../card/card.component";

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
    CardComponent
  ],
  templateUrl: './cardlist.component.html',
  styleUrl: './cardlist.component.css'
})
export class CardlistComponent implements OnChanges{
  cardLists?: CardlistVm[] = [];
  @Input() boardId?: string;
  @Input() boardName?: string;
  @Output() goToBoards = new EventEmitter();
  cardlistToEdit?: CardlistInputModel;
  cardToEdit?: CardInputModel;
  cardIdToShow?: string;

  constructor(private cardListService: CardListService, private cardService: CardService) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['boardId'] && !changes['boardId'].firstChange) {
      if(!this.boardId){
        this.cardLists = undefined;
      }
      else {
        this.loadCardLists();
      }
    }
  }

  loadCardLists() {
    this.cardListService
      .getCardListByBoard(this.boardId)
      .subscribe((result: CardlistVm[]) => (this.cardLists = result));
  }

  updateCardLists(){
    this.loadCardLists();
  }

  closeCardForm(){
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
    this.cardListService.deleteCardList(id, this.boardId).subscribe(
      (response) => {
        this.cardLists = response;
      },
    );
  }

  deleteCard(id: string){
    this.cardService.deleteCard(id, this.boardId).subscribe(
      (response) => {
        this.cardLists = response;
      },
    );
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
