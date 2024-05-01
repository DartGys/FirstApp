import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {CardService} from "../../../services/card.service";
import {CardInputModel} from "../../../models/input-models/card-input-model";
import {CardlistVm} from "../../../models/view-models/cardlist-vm";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {PriorityVm} from "../../../models/view-models/priority-vm";
import {CardlistVmList} from "../../../models/view-models/cardlist-vm-list";
import {CardListService} from "../../../services/cardList.service";
import {PriorityService} from "../../../services/priority.service";

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
export class EditCardComponent implements OnInit{
  @Input() card?: CardInputModel;
  @Output() cardlistsUpdated = new EventEmitter<CardlistVm[]>();
  @Output() cardFormClose = new EventEmitter();
   cardlists: CardlistVmList[] = [];
   priorities: PriorityVm[] = [];

  constructor(private cardService: CardService, private cardListService: CardListService,
              private priorityService: PriorityService) { }

  ngOnInit(): void {
    this.loadCardlists();
    this.loadPriorities();
  }

  loadCardlists() {
    this.cardListService.getCardListsList()
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
    this.cardFormClose.emit();
  }

  createCard(card: CardInputModel){
    console.log(card);
    this.cardService
      .createCard(card)
      .subscribe((cardlists: CardlistVm[]) => this.cardlistsUpdated.emit(cardlists));

    this.cancel();
  }

  updateCard(card: CardInputModel){
    this.cardService
      .updateCard(card)
      .subscribe((cardlists: CardlistVm[]) => this.cardlistsUpdated.emit(cardlists));

    this.cancel();
  }
}
