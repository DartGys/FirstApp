import {Component, Input, OnInit} from '@angular/core';
import {CardlistVm} from "../../models/view-models/cardlist-vm";
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
export class CardlistComponent implements OnInit{
  @Input() cardLists: CardlistVm[] = [];
  cardlistToEdit?: CardlistInputModel;
  cardToEdit?: CardInputModel;
  cardIdToShow?: string;

  constructor(private cardListService: CardListService, private cardService: CardService) { }

  ngOnInit(): void {
    this.cardListService
      .getCardLists()
      .subscribe((result: CardlistVm[]) => (this.cardLists = result));
  }

  updateCardLists(cardlists: CardlistVm[]){
    this.cardLists = cardlists;
  }

  closeCardForm(){
    this.cardToEdit = undefined;
  }

  closeCardListForm(){
    this.cardlistToEdit = undefined;
  }

  initNewCardList(){
    this.cardlistToEdit = new CardlistInputModel();
  }

  editCardList(cardlist: CardlistInputModel){
    this.cardlistToEdit = cardlist;
  }

  initNewCard(listId: string){
    this.cardToEdit = new CardInputModel();
    this.cardToEdit.cardListId = listId;
  }

  editCard(card: CardInputModel){
    this.cardToEdit = card;
  }

  showCard(cardId:string){
    this.cardIdToShow = cardId;
  }

  closeCard(){
    this.cardIdToShow = undefined;
  }

  deleteCardList(id: string){
    this.cardListService.deleteCardList(id).subscribe(
      (response) => {
        this.cardLists = response;
      },
    );
  }

  deleteCard(id: string){
    this.cardService.deleteCard(id).subscribe(
      (response) => {
        this.cardLists = response;
      },
    );
  }

  selectedListId= '';

  moveCardTo(cardId: string){
    this.cardService.updateCardList(cardId, this.selectedListId).subscribe(
      (response) => {
        this.cardLists = response;
      },
    );
    this.selectedListId = ''
  }
}
