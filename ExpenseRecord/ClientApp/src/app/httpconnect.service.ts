import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { ExpenseRecord } from './expenseRecord';




@Injectable({ providedIn: 'root' })
export class HttpconnectService {

  private itemsUrl = 'https://localhost:7081/api/Record';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<ExpenseRecord[]>(this.itemsUrl);
  }
  // updateItems(upDateitem:Item){
  //   return this.http.put<Item>(this.itemsUrl + '/' + upDateitem.id,upDateitem);
  // }
  insertItems(item:ExpenseRecord){
    return this.http.post<ExpenseRecord>(this.itemsUrl,item);
  }
  deleteItems(id:string){
    console.log(this.itemsUrl+'/'+id);
    return this.http.delete<ExpenseRecord>(this.itemsUrl+'/'+id);
  }
}


