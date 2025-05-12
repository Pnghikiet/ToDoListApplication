import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Todo } from '../shared/model/ToDo';
import { BehaviorSubject } from 'rxjs';
import { Pagination } from '../shared/model/Pagination';
import { Params } from '../shared/model/Params';
import { AuthService } from '../auth/auth.service';


@Injectable({
  providedIn: 'root'
})
export class TodoService {

  baseUrl = environment.apiUrl
  private todoSource = new BehaviorSubject<Todo[]>([])
  todo$ = this.todoSource.asObservable()
  pagination? :Pagination<Todo[]>
  params = new Params()
  
  
  constructor(private http: HttpClient, private authService: AuthService) { }

  getTodo()
  {
    let params = new HttpParams()

    const userId = this.authService.getUserId()

    params = params.append('pageindex',this.params.pageIndex)
    params = params.append('pagesize',this.params.pageSize)
    params = params.append('userid',userId)

    this.http.get<Pagination<Todo[]>>(this.baseUrl + "todos",{params}).subscribe({
      next: todo =>{
        this.todoSource.next(todo.data)
        this.pagination = todo
        console.log(todo)
      }
    })
  }

  setTodoSource()
  {
    this.todoSource.next([])
  }

  setParams(params: Params)
  {
    this.params =params
  }

  getParams()
  {
    return this.params
  }

  resetParams()
  {
    this.params = new Params()
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
    let params = new HttpParams()

    const userId = this.authService.getUserId()

    params = params.append('userId',userId)

    console.log(params)

    return this.http.post<Todo>(this.baseUrl + "todos" ,todo, { params})
  }

  updateTodo(todo: Todo)
  {
    let params = new HttpParams()

    const userId = this.authService.getUserId()

    params = params.append('userId',userId)

    return this.http.put<Todo>(this.baseUrl + "todos",todo,{params})
  }

  completeTodo(todo: Todo)
  {
    return this.http.patch<Todo>(this.baseUrl + 'todos/', todo)
  }

  getUsername(): string
  {
    return this.authService.getUserName()
  }
}
