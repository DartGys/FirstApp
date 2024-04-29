import {HistorylogVm} from "./historylog-vm";

export class CardVmDetails{
  id: string;
  name: string;
  description: string;
  createdDate: Date;
  dueDate: Date;
  priorityId: string;
  priorityName: string;
  cardListId: string;
  historyLog: HistorylogVm[];
}
