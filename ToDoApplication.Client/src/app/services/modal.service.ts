import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  title = ''
  isToggle = false

  constructor() { }

  openModal(titleModal: string)
  {
    if(titleModal)
    {
      this.title = titleModal
      this.isToggle = true
    }
  }

  closeModal()
  {
    this.title = ''
    this.isToggle = false
  }
}
