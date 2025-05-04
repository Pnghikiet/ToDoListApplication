import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Todo } from '../shared/model/ToDo';
import { BehaviorSubject } from 'rxjs';
import { Pagination } from '../shared/model/Pagination';
import { Params } from '../shared/model/Params';


@Injectable({
  providedIn: 'root'
})
export class TodoService {

  baseUrl = environment.apiUrl
  private todoSource = new BehaviorSubject<Todo[]>([])
  todo$ = this.todoSource.asObservable()
  pagination? :Pagination<Todo[]>
  params = new Params()
  
  
  constructor(private http: HttpClient) { }

  getTodo()
  {
    let params = new HttpParams()

    params = params.append('pageindex',this.params.pageIndex)
    params = params.append('pagesize',this.params.pageSize)

    this.http.get<Pagination<Todo[]>>(this.baseUrl + "todos",{params}).subscribe({
      next: todo =>{
        this.todoSource.next(todo.data)
        this.pagination = todo
      }
    })
  }

  setParams(params: Params)
  {
    this.params =params
  }

  getParams()
  {
    return this.params
  }

  removeTodoItemSource(id:number)
  {
    const current = this.todoSource.value
    const removedTodoItem = current.filter( todo => todo.id != id)
    this.todoSource.next(removedTodoItem)
  }

  DeleteTodo(id: number)
  {
    return this.http.delete<string>(this.baseUrl + "todos/" + id)
  }

  createTodo(todo : Todo)
  {
    return this.http.post<Todo>(this.baseUrl + "todos",todo)
  }

  updateTodo(todo: Todo)
  {
    return this.http.put<Todo>(this.baseUrl + "todos",todo)
  }
}
