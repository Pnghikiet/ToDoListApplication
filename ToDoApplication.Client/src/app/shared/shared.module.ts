import { NgModule } from '@angular/core';
import { NgxPaginationModule } from 'ngx-pagination';
import { ToastrModule } from 'ngx-toastr';
import { InputComponent } from './input/input.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MenuModule } from 'primeng/menu';
import { ButtonModule } from 'primeng/button'


@NgModule({
  declarations: [
    InputComponent
  ],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass:'toast-bottom-right',
      preventDuplicates: true
    }),
    ReactiveFormsModule,
    MenuModule,
    ButtonModule
  ],
  exports:[
    InputComponent,
    MenuModule,
    ButtonModule
  ]
})
export class SharedModule { }
