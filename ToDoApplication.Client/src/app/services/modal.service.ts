import { Injectable } from '@angular/core';
import { Todo } from '../shared/model/ToDo';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  title = ''
  todo?: Todo| null
  isToggle = false
  private dataSource = new BehaviorSubject<Todo | null>(null)
  dataSource$ = this.dataSource.asObservable()

  constructor() { }

  openModal(titleModal: string,todoValue? :Todo)
  {
    if(titleModal)
    {
      this.title = titleModal
      this.isToggle = true

      if(titleModal.toLocaleLowerCase() === 'update' && todoValue)
        this.setFormData(todoValue)
        this.todo = todoValue
    }
  }

  closeModal()
  {
    this.todo = null
    this.title = ''
    this.isToggle = false
    this.dataSource.next(null)
  }

  setFormData(data: Todo)
  {
    this.dataSource.next(data)
  }
}
