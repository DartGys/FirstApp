import {Component, EventEmitter, Input, Output} from '@angular/core';
import {CardlistInputModel} from "../../../../models/input-models/cardlist-input-model";
import {CardlistVm} from "../../../../models/view-models/cardlist-vm";
import {CardListService} from "../../../../services/cardList.service";
import {NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";

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
  @Output() cardlistsUpdated = new EventEmitter<CardlistVm[]>();

  constructor(private cardListService: CardListService) { }

  createCardList(cardlist: CardlistInputModel){
    this.cardListService
      .createCardList(cardlist);
  }

  updateCardList(cardlist: CardlistInputModel){
    this.cardListService
      .updateCardList(cardlist)
      .subscribe((cardlists: CardlistVm[]) => this.cardlistsUpdated.emit(cardlists));
  }

  deleteCardList(cardlist: CardlistInputModel){
    this.cardListService
      .deleteCardList(cardlist.id)
      .subscribe((cardlists: CardlistVm[]) => this.cardlistsUpdated.emit(cardlists));
  }
}
