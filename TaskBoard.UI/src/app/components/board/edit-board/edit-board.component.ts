import {Component, EventEmitter, Input, Output} from '@angular/core';
import {CardlistInputModel} from "../../../models/input-models/cardlist-input-model";
import {BoardService} from "../../../services/board.service";
import {BoardInputModel} from "../../../models/input-models/board-input-model";
import {BoardVm} from "../../../models/view-models/board-vm";
import {FormsModule} from "@angular/forms";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-edit-board',
  standalone: true,
  imports: [
    FormsModule,
    NgIf
  ],
  templateUrl: './edit-board.component.html',
  styleUrl: './edit-board.component.css'
})
export class EditBoardComponent {
  @Input() board?: BoardInputModel;
  @Output() boardsUpdated = new EventEmitter<BoardVm[]>();
  @Output() boardFormClose = new EventEmitter();
  errors: { [key: string]: string[] } = {};


  constructor(private boardService: BoardService) { }

  createBoard(board: BoardInputModel){

    this.errors = board.validate();

    if (Object.keys(this.errors).length > 0) {
      return;
    }

    this.boardService
      .createBoard(board)
      .subscribe((boards: BoardVm[]) => this.boardsUpdated.emit(boards));

    this.cancel();
  }

  updateBoard(board: BoardInputModel){

    this.errors = board.validate();

    if (Object.keys(this.errors).length > 0) {
      return;
    }

    this.boardService
      .updateBoard(board)
      .subscribe((boards: BoardVm[]) => this.boardsUpdated.emit(boards));

    this.cancel();
  }

  cancel(){
    this.boardFormClose.emit();
    this.errors = {};
  }
}
