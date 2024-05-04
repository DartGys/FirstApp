import {Component, EventEmitter, Input, OnChanges, Output, SimpleChanges} from '@angular/core';
import {HistorylogVm} from "../../models/view-models/historylog-vm";
import {DatePipe, NgForOf, NgIf} from "@angular/common";
import {HistoryLogService} from "../../services/history-log.service";

@Component({
  selector: 'app-history-log',
  standalone: true,
  imports: [
    NgForOf,
    DatePipe,
    NgIf
  ],
  templateUrl: './history-log.component.html',
  styleUrl: './history-log.component.css'
})
export class HistoryLogComponent implements OnChanges{
  historyLogs?: HistorylogVm[];
  @Output() historyLogClose = new EventEmitter();
  @Input() isOpen!: boolean;

  constructor(private historyLogService: HistoryLogService) { }

  close(){
    this.historyLogClose.emit();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.historyLogs = undefined;
    if (changes['isOpen'] && !changes['isOpen'].firstChange) {
      this.loadHistory();
    }
  }

  loadHistory() {

    let lastRecord = this.historyLogs?.length || 0;

    this.historyLogService
      .getTwentyRecords(lastRecord)
      .subscribe((result: HistorylogVm[]) => {
        if (!this.historyLogs) {
          this.historyLogs = result;
        } else {
          if (result && result.length > 0) {
            this.historyLogs.push(...result);
          }
        }
      });
  }
}
