import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TodoService } from '../todo.service';
import { Todo } from '../../shared/model/ToDo';
import Swal from 'sweetalert2';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { ModalService } from '../../services/modal.service';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrl: './todo-item.component.css'
})
export class TodoItemComponent implements OnInit{

  todoListItem: Todo[] =[]
  @Output() emitEvent = new EventEmitter<Todo>()

  constructor(public todoService: TodoService, private http: HttpClient,
    private toastrService: ToastrService, public modalService: ModalService){}

  ngOnInit(): void {
    this.todoService.getTodo()
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
    this.todoService.DeleteTodo(id).subscribe({
      next: success => {
        this.toastrService.success("Delete complete")
        this.todoService.removeTodoItemSource(id)
      },
      error: err => {
        this.toastrService.error("Problem with delete item")
      }
    })
  }

}
