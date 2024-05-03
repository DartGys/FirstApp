import {HistorylogVm} from "./historylog-vm";

export class CardVmDetails{
  id= '';
  name= '';
  description= '';
  createdDate: Date = new Date();
  dueDate: Date = new Date();
  priorityId= '';
  priorityName= '';
  cardListId= '';
  cardListName= '';
  historyLogs: HistorylogVm[] = [];
}
