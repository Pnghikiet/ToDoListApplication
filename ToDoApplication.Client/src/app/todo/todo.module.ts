import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoComponent } from './todo.component';
import { TodoItemComponent } from './todo-item/todo-item.component';
import { HttpClientModule } from '@angular/common/http';
import { TodoModalComponent } from './todo-modal/todo-modal.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule} from '@angular/material/input';
import { NgxPaginationModule } from 'ngx-pagination';



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
    ReactiveFormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    NgxPaginationModule
  ],
  exports:[
    TodoComponent
  ]
})
export class TodoModule { }
