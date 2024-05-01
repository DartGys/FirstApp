import {Component, Input} from '@angular/core';
import {HistorylogVm} from "../../models/view-models/historylog-vm";
import {DatePipe, NgForOf} from "@angular/common";

@Component({
  selector: 'app-history-log',
  standalone: true,
  imports: [
    NgForOf,
    DatePipe
  ],
  templateUrl: './history-log.component.html',
  styleUrl: './history-log.component.css'
})
export class HistoryLogComponent {
  @Input() historyLogs?: HistorylogVm[];



  close(){

  }
}
