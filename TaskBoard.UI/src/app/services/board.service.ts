import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {BoardVm} from "../models/view-models/board-vm";
import {environment} from "../../enviroments/enviroment";
import {BoardInputModel} from "../models/input-models/board-input-model";

@Injectable({
  providedIn: 'root'
})
export class BoardService {
  private url = "board";
  constructor(private http: HttpClient) { }

  public getBoards() : Observable<BoardVm[]>{
    return this.http.get<BoardVm[]>(`${environment.apiUrl}/${this.url}`);
  }

  public createBoard(board: BoardInputModel) : Observable<BoardVm[]>{
    return this.http.post<BoardVm[]>(`${environment.apiUrl}/${this.url}`, board);
  }

  public updateBoard(board: BoardInputModel) : Observable<BoardVm[]>{
    return this.http.patch<BoardVm[]>(`${environment.apiUrl}/${this.url}`, board);
  }

  public deleteBoard(boardId: string) : Observable<BoardVm[]>{
    return this.http.delete<BoardVm[]>(`${environment.apiUrl}/${this.url}/${boardId}`)
  }
}
