import { Component, OnInit } from '@angular/core';
import { TodoService } from '../todo.service';
import { Todo } from '../../shared/model/ToDo';
import Swal from 'sweetalert2';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrl: './todo-item.component.css'
})
export class TodoItemComponent implements OnInit{

  todoListItem: Todo[] =[]

  constructor(private todoService: TodoService, private http: HttpClient, private toastrService: ToastrService){}

  ngOnInit(): void {
    this.todoService.getTodo().subscribe({
      next: todos => this.todoListItem = todos,
      error: err => console.log("Error connection")
    })
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
        this.toastrService.success(success)
      },
      error: err => {
        console.log(err)
        this.toastrService.error("Problem with delete item")
      }
    })
  }

}
