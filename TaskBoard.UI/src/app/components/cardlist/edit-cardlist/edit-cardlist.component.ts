import {Component, EventEmitter, Input, Output} from '@angular/core';
import {NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {CardlistVm} from "../../../models/view-models/cardlist-vm";
import {CardlistInputModel} from "../../../models/input-models/cardlist-input-model";
import {CardListService} from "../../../services/cardList.service";

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
  @Output() cardListFormClose = new EventEmitter();
  errors: { [key: string]: string[] } = {};


  constructor(private cardListService: CardListService) { }

  createCardList(cardlist: CardlistInputModel){

    this.errors = cardlist.validate();

    if (Object.keys(this.errors).length > 0) {
      return;
    }

    this.cardListService
      .createCardList(cardlist)
      .subscribe((cardlists: CardlistVm[]) => this.cardlistsUpdated.emit(cardlists));

    this.cancel();
  }

  updateCardList(cardlist: CardlistInputModel){

    this.errors = cardlist.validate();

    if (Object.keys(this.errors).length > 0) {
      return;
    }

    this.cardListService
      .updateCardList(cardlist)
      .subscribe((cardlists: CardlistVm[]) => this.cardlistsUpdated.emit(cardlists));

    this.cancel();
  }

  cancel(){
    this.cardListFormClose.emit();
    this.errors = {};
  }
}
