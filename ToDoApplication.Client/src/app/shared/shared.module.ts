import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [],
  imports: [
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass:'toast-bottom-right',
      preventDuplicates: true,
    })    
  ],
  exports:[
  ]
})
export class SharedModule { }
