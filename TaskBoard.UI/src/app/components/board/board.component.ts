import {Component, Input, OnInit} from '@angular/core';
import {NgForOf} from "@angular/common";
import {BoardVm} from "../../models/view-models/board-vm";

@Component({
  selector: 'app-board',
  standalone: true,
    imports: [
        NgForOf
    ],
  templateUrl: './board.component.html',
  styleUrl: './board.component.css'
})
export class BoardComponent implements OnInit{
  @Input() boards : BoardVm[] = [];

  ngOnInit(): void {
  }
}
