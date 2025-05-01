import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Todo } from '../shared/model/ToDo';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TodoService {

  baseUrl = environment.apiUrl
  private todoSource = new BehaviorSubject<Todo[]>([])
  todo$ = this.todoSource.asObservable()
  
  
  constructor(private http: HttpClient) { }

  getTodo()
  {
    this.http.get<Todo[]>(this.baseUrl + "todos").subscribe({
      next: todo =>{
        this.todoSource.next(todo)
      }
    })
  }

  addTodoSource(todo: Todo)
  {
    const current = this.todoSource.value
    this.todoSource.next([...current, todo])
  }

  updateTodoSource(todo: Todo)
  {
    const current = this.todoSource.value
    const updatedTodo = current.map(todoToUpdate => 
      todoToUpdate.id === todo.id ? {...todoToUpdate, ...todo} : todoToUpdate
    )
    this.todoSource.next(updatedTodo)
    
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
