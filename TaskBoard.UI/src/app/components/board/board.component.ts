import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {BoardVm} from "../../models/view-models/board-vm";
import {BoardService} from "../../services/board.service";
import {CardlistVm} from "../../models/view-models/cardlist-vm";
import {CardlistInputModel} from "../../models/input-models/cardlist-input-model";
import {BoardInputModel} from "../../models/input-models/board-input-model";

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [
    NgForOf,
    NgIf
  ],
  templateUrl: './board.component.html',
  styleUrl: './board.component.css'
})
export class BoardComponent implements OnInit{
  @Input() boards : BoardVm[] = [];
  @Output() boardOpen = new EventEmitter();
  boardToEdit?: BoardInputModel;

  constructor(private boardService: BoardService) { }

  ngOnInit(): void {
    this.boardService
      .getBoards()
      .subscribe((result: BoardVm[]) => (this.boards = result));
  }

  openBoard(id: string){
    this.boardOpen.emit(id);
  }

  editBoard(board: BoardVm){

  }

  deleteBoard(boardId: string){

  }

  initNewBoard(){

  }
}
