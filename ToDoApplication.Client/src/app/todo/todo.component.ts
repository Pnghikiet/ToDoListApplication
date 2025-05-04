import { Component, OnInit } from '@angular/core';
import { ModalService } from '../services/modal.service';
import { TodoService } from './todo.service';
import { Todo } from '../shared/model/ToDo';
import { BehaviorSubject, Observable } from 'rxjs';
import { Params } from '../shared/model/Params';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.css'
})
export class TodoComponent implements OnInit{
  SearchValue:string = ""

  constructor(public modalService: ModalService,public todoService: TodoService){}

  ngOnInit(): void {
    this.getTodo()
  }
  
  getTodo()
  {
    this.todoService.getTodo()
  }

  onPageChange(event: any)
  {
    if(this.todoService.pagination?.pageIndex !== event)
    {
      const params = this.todoService.getParams()
      params.pageIndex = event
      this.todoService.setParams(params)
      this.getTodo()
    }
  }

}
