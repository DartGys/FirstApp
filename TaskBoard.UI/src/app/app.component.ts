import {Component, Input} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {CardlistVm} from "./models/view-models/cardlist-vm";
import {DatePipe, NgForOf, NgIf} from "@angular/common";
import {CardlistComponent} from "./components/cardlist/cardlist.component";
import {HistoryLogComponent} from "./components/history-log/history-log.component";
import {BoardComponent} from "./components/board/board.component";
import {BoardVm} from "./models/view-models/board-vm";


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
  boardName?: string;


  constructor() { }

  openBoard(board: BoardVm){
    this.boardId = board.id;
    this.boardName = board.name;
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
