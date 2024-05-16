import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../enviroments/enviroment";
import {CardVmDetails} from "../models/view-models/card-vm-details";
import {CardInputModel} from "../models/input-models/card-input-model";
import {CardlistVm} from "../models/view-models/cardlist-vm";

@Injectable({
  providedIn: 'root'
})
export class CardService {
  private url = "card";

  constructor(private http: HttpClient) { }

  public getCard(cardId?: string) : Observable<CardVmDetails>{
    return this.http.get<CardVmDetails>(`${environment.apiUrl}/${this.url}/${cardId}`);
  }

  public createCard(card?: CardInputModel) : Observable<CardlistVm[]>{
    return this.http.post<CardlistVm[]>(`${environment.apiUrl}/${this.url}`, card);
  }

  public updateCard(card: CardInputModel) : Observable<CardlistVm[]>{
    console.log(card);
    return this.http.patch<CardlistVm[]>(`${environment.apiUrl}/${this.url}`, card);
  }

  public updateCardList(cardId: string, listId: string, boardId?: string) : Observable<CardlistVm[]>{
    return this.http.patch<CardlistVm[]>(`${environment.apiUrl}/${this.url}/${cardId}/list/${listId}/board/${boardId}`, {});
  }

  public deleteCard(cardId?: string, boardId?: string) : Observable<CardlistVm[]>{
    console.log(`cardId: ${cardId}`);
    return this.http.delete<CardlistVm[]>(`${environment.apiUrl}/${this.url}/${cardId}/board/${boardId}`);
  }
}
