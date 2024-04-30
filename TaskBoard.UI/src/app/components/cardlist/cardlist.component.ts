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

  updateCardLists(){
    this.cardListService.getCardLists().subscribe(
      (cardlists: CardlistVm[]) => {
        this.cardLists = cardlists;
      });
  }

  initNewCardList(){
    this.cardlistToEdit = new CardlistInputModel();
  }

  addCardButton(){

  }
}
