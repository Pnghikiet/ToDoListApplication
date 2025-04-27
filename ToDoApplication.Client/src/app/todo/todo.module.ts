import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoComponent } from './todo.component';
import { TodoItemComponent } from './todo-item/todo-item.component';
import { HttpClientModule } from '@angular/common/http';
import { TodoModalComponent } from './todo-modal/todo-modal.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    TodoComponent,
    TodoItemComponent,
    TodoModalComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    SweetAlert2Module.forRoot(),
    SharedModule,
    ReactiveFormsModule
  ],
  exports:[
    TodoComponent
  ]
})
export class TodoModule { }
