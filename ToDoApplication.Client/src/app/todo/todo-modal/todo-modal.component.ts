import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TodoService } from '../todo.service';
import { environment } from '../../../environments/environment.development';
import { Todo } from '../../shared/model/ToDo';

@Component({
  selector: 'app-todo-modal',
  templateUrl: './todo-modal.component.html',
  styleUrl: './todo-modal.component.css'
})
export class TodoModalComponent {
  @Input() isVisibility = false
  @Output() ModalcloseEvent = new EventEmitter<boolean>()
  @Input() todoId: number = 0
  baseUrl = environment.apiUrl

  constructor(private http: HttpClient, private todoSerevie: TodoService){}


  onCloseModal()
  {
    this.isVisibility =true
    this.ModalcloseEvent.emit(false)
  }

  onDeleteItem()
  {
    return this.http.delete<Todo>(this.baseUrl + "delete").subscribe({
      next: success => success
    })
  }
}
