import {Component, Input, OnInit} from '@angular/core';
import {CardlistVm} from "../../models/view-models/cardlist-vm";
import {CardListService} from "../../services/cardList.service";
import {DatePipe, NgForOf, NgIf} from "@angular/common";
import {EditCardlistComponent} from "./edit-cardlist/edit-cardlist/edit-cardlist.component";
import {CardlistInputModel} from "../../models/input-models/cardlist-input-model";

@Component({
  selector: 'app-cardlist',
  standalone: true,
  imports: [
    NgForOf,
    DatePipe,
    NgIf,
    EditCardlistComponent
  ],
  templateUrl: './cardlist.component.html',
  styleUrl: './cardlist.component.css'
})
export class CardlistComponent implements OnInit{
  @Input() cardLists: CardlistVm[] = [];
  cardlistToEdit?: CardlistInputModel;
  constructor(private cardListService: CardListService) { }

  ngOnInit(): void {
    this.cardListService
      .getCardLists()
      .subscribe((result: CardlistVm[]) => (this.cardLists = result));
  }

  updateCardLists(cardlists: CardlistVm[]){
    this.cardLists = cardlists;

    this.cardlistToEdit = undefined;
  }

  initNewCardList(){
    this.cardlistToEdit = new CardlistInputModel();
  }

  editCardList(cardlist: CardlistInputModel){
    this.cardlistToEdit = cardlist;
  }

  deleteCardList(id: string){
    this.cardListService.deleteCardList(id).subscribe(
      (response) => {
        this.cardLists = response;
      },
    );
  }

  addCardButton(){

  }
}
