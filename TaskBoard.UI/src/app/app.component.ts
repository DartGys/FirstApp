import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {CardlistVm} from "./models/view-models/cardlist-vm";
import {DatePipe, NgForOf} from "@angular/common";
import {CardlistComponent} from "./components/cardlist/cardlist.component";
import {HistoryLogComponent} from "./components/history-log/history-log.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgForOf, DatePipe, CardlistComponent, HistoryLogComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TaskBoard.UI';
  cardLists: CardlistVm[] = [];
  isSidebarOpen: boolean = false;

  constructor() { }

  openSidebar() {
    this.isSidebarOpen = true;
  }

  closeSidebar(){
    this.isSidebarOpen = false;
  }
}
