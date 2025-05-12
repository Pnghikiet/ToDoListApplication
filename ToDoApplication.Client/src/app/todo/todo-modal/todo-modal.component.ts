import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TodoService } from '../todo.service';
import { environment } from '../../../environments/environment.development';
import { ModalService } from '../../services/modal.service';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { validDate } from '../../shared/Validators/CheckValidDate';
import { Todo } from '../../shared/model/ToDo';
import { ToastrService } from 'ngx-toastr';
import moment from 'moment-timezone';

@Component({
  selector: 'app-todo-modal',
  templateUrl: './todo-modal.component.html',
  styleUrl: './todo-modal.component.css'
})
export class TodoModalComponent implements OnInit{
  @Input() isVisibility = false
  baseUrl = environment.apiUrl
  todoForm = new FormGroup({
    id: new FormControl(),
    title: new FormControl('',Validators.required),
    description: new FormControl('',Validators.required),
    isCleared:new FormControl(false),
    priority: new FormControl('',Validators.required),
    duedate: new FormControl<Date>(new Date,[Validators.required,validDate()])
  })

  constructor(private todoService: TodoService, public modalService: ModalService,
    private toastr : ToastrService
  ){}

  ngOnInit(): void {
    this.modalService.dataSource$.subscribe(
      data => {
        if(data)
        {
          this.todoForm.controls.title.setValue(data.title)
          this.todoForm.controls.priority.patchValue(data.priority)
          this.todoForm.controls.description.setValue(data.description)
          this.todoForm.controls.duedate.setValue(new Date(data.dueDate))
          this.todoForm.controls.id.setValue(data.id)
          this.todoForm.controls.isCleared.setValue(data.isCleared)
        }
      }
    )
  }

  

  onCreateOrUpdate()
  {
    if(this.modalService.title.toLowerCase() === 'update')
    {
      const formatedTodoData = this.convertDateToString()

      this.todoService.updateTodo(formatedTodoData as Todo).subscribe({
        next: data => {
          this.toastr.success('Update completed')
          this.CloseModal()
          this.todoService.getTodo()
        }
      })
    }
    if(this.modalService.title.toLocaleLowerCase() === 'create')
    {
      const formatedTodoData = this.convertDateToString()

      this.todoService.createTodo(formatedTodoData as Todo).subscribe({
        next: data => {
          this.toastr.success('Create success')
          this.CloseModal()
          this.todoService.getTodo()
        }
      })
    }
  }

  CloseModal()
  {
    this.todoForm.reset()
    this.todoForm.controls.isCleared.setValue(false)
    this.todoForm.controls.duedate.setValue(new Date)
    this.modalService.closeModal() 
  }

  private convertDateToString()
  {
    const todoData = this.todoForm.value
      
    const formatedData = Object.entries(todoData).reduce((acc,[key,value]) =>{
      if(value instanceof Date)
      {
        const date = moment.utc(value).tz('Asia/Bangkok').format()
        acc[key] = date
      }
      else
        acc[key] = value
      return acc
    }, {} as Record<string,any>)

    return formatedData
  }
}
