import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Todo } from '../../shared/model/ToDo';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  baseUrl = environment.apiUrl
  
  constructor(private http: HttpClient) { }

  getTodo()
  {
    return this.http.get<Todo[]>(this.baseUrl + "todos")
  }
}
