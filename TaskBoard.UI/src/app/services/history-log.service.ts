import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../enviroments/enviroment";
import {HistorylogVm} from "../models/view-models/historylog-vm";

@Injectable({
  providedIn: 'root'
})
export class HistoryLogService {
private url = 'historylog';
  constructor(private http: HttpClient) { }

  public getTwentyRecords(lastRecord: number) : Observable<HistorylogVm[]>{
    return this.http.get<HistorylogVm[]>(`${environment.apiUrl}/${this.url}/record/${lastRecord}`);
  }
}
