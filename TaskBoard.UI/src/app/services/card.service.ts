import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../enviroments/enviroment";
import {CardVmDetails} from "../models/view-models/card-vm-details";
import {CardInputModel} from "../models/input-models/card/card-input-model";
import {CardlistVm} from "../models/view-models/cardlist-vm";

@Injectable({
  providedIn: 'root'
})
export class CardService {
  private url = "card";

  constructor(private http: HttpClient) { }

  public getCard() : Observable<CardVmDetails>{
    return this.http.get<CardVmDetails>(`${environment.apiUrl}/${this.url}`);
  }

  public createCard(card: CardInputModel) : Observable<CardVmDetails[]>{
    return this.http.post(`${environment.apiUrl}/${this.url}`, card);
  }

  public updateCard(card: CardUpdateModel) : Observable<CardVmDetails[]>{
    return this.http.patch(`${environment.apiUrl}/${this.url}`, card);
  }

  public updateCard(cardId: string, listId: string) : Observable<CardVmDetails[]>{
    return this.http.patch(`${environment.apiUrl}/${this.url}/${cardId}/list/${listId}`, {});
  }

  public updateCard(cardId: string, priorityId: string) : Observable<CardVmDetails[]>{
    return this.http.patch(`${environment.apiUrl}/${this.url}/${cardId}/list/${priorityId}`, {});
  }

  public deleteCard(cardId: string) : Observable<CardVmDetails[]>{
    return this.http.delete(`${environment.apiUrl}/${this.url}/${cardId}`);
  }
}
