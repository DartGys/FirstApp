import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {CardlistVm} from "../models/view-models/cardlist-vm";
import {environment} from "../../enviroments/enviroment";
import {PriorityVm} from "../models/view-models/priority-vm";

@Injectable({
  providedIn: 'root'
})
export class PriorityService {
  private url = 'priority';

  constructor(private http: HttpClient) { }

  public getPriorities() : Observable<PriorityVm[]>{
    return this.http.get<PriorityVm[]>(`${environment.apiUrl}/${this.url}`);
  }
}
