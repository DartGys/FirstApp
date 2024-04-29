import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {CardlistVm} from "./models/view-models/cardlist-vm";
import {DatePipe, NgForOf} from "@angular/common";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgForOf, DatePipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TaskBoard.UI';
  cardLists: CardlistVm[] = [];

  constructor() { }

}
