import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {CardlistVm} from "../models/view-models/cardlist-vm";
import {environment} from "../../enviroments/enviroment";
import {CardlistInputModel} from "../models/input-models/cardlist-input-model";

@Injectable({
  providedIn: 'root'
})
export class CardListService {
  private url = "cardlist";

  constructor(private http: HttpClient) { }

  public getCardLists() : Observable<CardlistVm[]>{
    return this.http.get<CardlistVm[]>(`${environment.apiUrl}/${this.url}`);
  }

  public createCardList(cardList: CardlistInputModel) : Observable<CardlistVm[]>{
    return this.http.post(`${environment.apiUrl}/${this.url}`, cardList);
  }

  public updateCardList(cardList: CardlistInputModel) : Observable<CardlistVm>{
    return this.http.put(`${environment.apiUrl}/${this.url}`, cardList);
  }

  public deleteCardList(cardListId: string) : Observable<CardlistVm>{
    return this.http.delete(`${environment.apiUrl}/${this.url}/${cardListId}`);
  }
}
