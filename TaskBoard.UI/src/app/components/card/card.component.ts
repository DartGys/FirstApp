import {Component, EventEmitter, Input, OnChanges, Output, SimpleChanges} from '@angular/core';
import {CardVmDetails} from "../../models/view-models/card-vm-details";
import {FormsModule} from "@angular/forms";
import {DatePipe, NgForOf, NgIf} from "@angular/common";
import {CardService} from "../../services/card.service";

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [
    FormsModule,
    NgIf,
    DatePipe,
    NgForOf
  ],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent implements OnChanges{
  @Output() cardClose = new EventEmitter();
  @Input() cardId?: string;
  card?: CardVmDetails;

  constructor(private cardService: CardService) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['cardId'] && !changes['cardId'].firstChange && this.cardId) {
      this.loadCardVm();
    }
  }

  loadCardVm(){
    if(this.cardId) {
      this.cardService.getCard(this.cardId)
        .subscribe((data: CardVmDetails) => {
          console.log(data);
          this.card = data;
        });
    }
  }

  cancel(){
    this.cardClose.emit();
    this.card = undefined;
  }
}
