import { Component, OnInit } from '@angular/core';
import { TodoService } from '../todo.service';
import { Todo } from '../../../shared/model/ToDo';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrl: './todo-item.component.css'
})
export class TodoItemComponent implements OnInit{

  todoListItem?: Todo[] =[]

  constructor(private todoService: TodoService){}

  ngOnInit(): void {
    this.todoService.getTodo().subscribe({
      next: todos => this.todoListItem = todos
    })
  }

  
}
