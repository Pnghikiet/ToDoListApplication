import { Component, OnInit } from '@angular/core';
import { ModalService } from '../services/modal.service';
import { TodoService } from './todo.service';
import { Todo } from '../shared/model/ToDo';
import { BehaviorSubject, Observable } from 'rxjs';
import { Params } from '../shared/model/Params';
import { MenuItem } from 'primeng/api';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.css'
})
export class TodoComponent implements OnInit{
  SearchValue:string = ""
  menuValue : MenuItem[]| undefined = [
    {label: 'Logout', command: () => this.logout()}
  ]
  userName? :string

  constructor(public modalService: ModalService,public todoService: TodoService
    ,private router: Router
  ){}

  ngOnInit(): void {
    this.getTodo()
    this.userName = this.todoService.getUsername()
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

  logout()
  {
    localStorage.removeItem('token')
    this.router.navigateByUrl('account/login')
    this.todoService.setTodoSource()
  }

}
