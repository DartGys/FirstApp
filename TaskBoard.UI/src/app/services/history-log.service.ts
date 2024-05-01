import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {CardVmDetails} from "../models/view-models/card-vm-details";
import {environment} from "../../enviroments/enviroment";
import {CardlistVm} from "../models/view-models/cardlist-vm";
import {HistorylogVm} from "../models/view-models/historylog-vm";
import {HistorylogUpdateCardlist} from "../models/input-models/historylog/historylog-update-cardlist";
import {HistorylogInputDeleteAddModel} from "../models/input-models/historylog/historylog-inout-delete-add-model";
import {log} from "@angular-devkit/build-angular/src/builders/ssr-dev-server";
import {HistorylogUpdateCardname} from "../models/input-models/historylog/historylog-update-cardname";
import {HistorylogUpdateCardpriority} from "../models/input-models/historylog/historylog-update-cardpriority";

@Injectable({
  providedIn: 'root'
})
export class HistoryLogService {
private url = 'historylog';
  constructor(private http: HttpClient) { }

  public getAllHistory() : Observable<HistorylogVm[]>{
    return this.http.get<HistorylogVm[]>(`${environment.apiUrl}/${this.url}`);
  }

  public getTwentyRecords(lastRecord: number) : Observable<HistorylogVm[]>{
    return this.http.get<HistorylogVm[]>(`${environment.apiUrl}/${this.url}/record/${lastRecord}`);
  }

  public logCardAdd(logAdd: HistorylogInputDeleteAddModel) : Observable<HistorylogVm[]>{
    return this.http.post<HistorylogVm[]>(`${environment.apiUrl}/${this.url}/move`, logAdd);
  }

  public logCardMove(logMove: HistorylogUpdateCardlist) : Observable<HistorylogVm[]>{
    return this.http.post<HistorylogVm[]>(`${environment.apiUrl}/${this.url}/move`, logMove);
  }

  public logCardNameUpdate(logNameUpdate: HistorylogUpdateCardname) : Observable<HistorylogVm[]>{
    return this.http.post<HistorylogVm[]>(`${environment.apiUrl}/${this.url}/move`, logNameUpdate);
  }

  public logCardPriorityUpdate(logPriorityUpdate: HistorylogUpdateCardpriority) : Observable<HistorylogVm[]>{
    return this.http.post<HistorylogVm[]>(`${environment.apiUrl}/${this.url}/move`, logPriorityUpdate);
  }

  public logCardDelete(logDelete: HistorylogInputDeleteAddModel) : Observable<HistorylogVm[]>{
    return this.http.post<HistorylogVm[]>(`${environment.apiUrl}/${this.url}/move`, logDelete);
  }
}
