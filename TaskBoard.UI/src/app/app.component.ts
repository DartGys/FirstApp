import {Component, Input} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {CardlistVm} from "./models/view-models/cardlist-vm";
import {DatePipe, NgForOf, NgIf} from "@angular/common";
import {CardlistComponent} from "./components/cardlist/cardlist.component";
import {HistoryLogComponent} from "./components/history-log/history-log.component";
import {BoardComponent} from "./components/board/board.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgForOf, DatePipe, CardlistComponent, HistoryLogComponent, BoardComponent, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TaskBoard.UI';
  isSidebarOpen: boolean = false;
  boardId?: string;


  constructor() { }

  openBoard(boardId: string){
    this.boardId = boardId;
    console.log(this.boardId)
  }

  closeBoard(){
    this.boardId = undefined;
  }

  openSidebar() {
    this.isSidebarOpen = true;
  }

  closeSidebar(){
    this.isSidebarOpen = false;
  }
}
