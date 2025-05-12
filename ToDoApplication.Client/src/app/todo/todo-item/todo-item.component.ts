import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TodoService } from '../todo.service';
import { Todo } from '../../shared/model/ToDo';
import Swal from 'sweetalert2';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { ModalService } from '../../services/modal.service';
import { Params } from '../../shared/model/Params';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrl: './todo-item.component.css'
})
export class TodoItemComponent implements OnInit{
  @Input() todoItem?: Todo
  
  @Output() emitEvent = new EventEmitter<Todo>()

  constructor(public todoService: TodoService,
    private toastrService: ToastrService, public modalService: ModalService){}

  ngOnInit(): void {
  }

  onShowAlert(id:number)
  {
    Swal.fire({
      title: 'Delete?',
      text: 'Are you sure to delete this todo?',
      icon: 'warning',
      showCancelButton: true,
      cancelButtonText: "Cancel",
      confirmButtonText: "Delete"
    }).then(result =>{
      if(result.isConfirmed)
        this.onDeleteItem(id)
    })
  }

  onDeleteItem(id: number)
  {
    this.todoService.resetParams()
    this.todoService.DeleteTodo(id).subscribe({
      next: success => {
        this.toastrService.success("Delete complete")
        this.todoService.removeTodoItemSource(id)
        this.todoService.getTodo()
      },
      error: err => {
        this.toastrService.error("Problem with delete item")
      }
    })
  }

  onCleared(todo: Todo)
  {
    this.todoService.resetParams()
    this.todoService.completeTodo(todo).subscribe({
      next: result => {
        this.todoService.getTodo()
      }
    })
  }

}
