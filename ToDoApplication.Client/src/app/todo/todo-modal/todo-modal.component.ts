import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TodoService } from '../todo.service';
import { environment } from '../../../environments/environment.development';
import { ModalService } from '../../services/modal.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-todo-modal',
  templateUrl: './todo-modal.component.html',
  styleUrl: './todo-modal.component.css'
})
export class TodoModalComponent {
  @Input() isVisibility = false
  baseUrl = environment.apiUrl
  todoForm = new FormGroup({
    title: new FormControl('',Validators.required),
    description: new FormControl('',Validators.required),
    priority: new FormControl('',Validators.required),
  })

  constructor(private http: HttpClient, private todoSerevie: TodoService, public modalService: ModalService){}

  CreateOrUpdate()
  {
    
  }
}
