import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {BoardVm} from "../../models/view-models/board-vm";
import {BoardService} from "../../services/board.service";
import {CardlistVm} from "../../models/view-models/cardlist-vm";
import {CardlistInputModel} from "../../models/input-models/cardlist-input-model";
import {BoardInputModel} from "../../models/input-models/board-input-model";
import {EditCardlistComponent} from "../cardlist/edit-cardlist/edit-cardlist.component";
import {EditBoardComponent} from "./edit-board/edit-board.component";

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [
    NgForOf,
    NgIf,
    EditCardlistComponent,
    EditBoardComponent
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

  openBoard(board: BoardVm){
    this.boardOpen.emit(board);
  }

  updateBoards(boards: BoardVm[]){
    this.boards = boards;
  }

  editBoard(board: BoardVm){
    this.boardToEdit = Object.assign(new CardlistInputModel(), {
      id: board.id,
      name: board.name
    })
  }

  deleteBoard(id: string){
    this.boardService.deleteBoard(id).subscribe(
      (response) => {
        this.boards = response;
      },
    );
  }

  initNewBoard(){
    this.boardToEdit = new BoardInputModel();
  }

  closeBoardForm(){
    this.boardToEdit = undefined;
  }
}
