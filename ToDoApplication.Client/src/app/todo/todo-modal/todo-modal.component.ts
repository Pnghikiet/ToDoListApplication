import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TodoService } from '../todo.service';
import { environment } from '../../../environments/environment.development';
import { Todo } from '../../shared/model/ToDo';
import { ModalService } from '../../services/modal.service';

@Component({
  selector: 'app-todo-modal',
  templateUrl: './todo-modal.component.html',
  styleUrl: './todo-modal.component.css'
})
export class TodoModalComponent {
  @Input() isVisibility = false
  baseUrl = environment.apiUrl
  

  constructor(private http: HttpClient, private todoSerevie: TodoService, public modalService: ModalService){}


}
