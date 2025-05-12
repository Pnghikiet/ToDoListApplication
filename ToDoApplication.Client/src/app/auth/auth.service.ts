import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  getToken() : string | null{
    return  localStorage.getItem('token')
  }

  getDecodedToken() :any
  {
    const token = this.getToken()
    if(!token)
      return null
    return jwtDecode(token)
  }

  getUserId()
  {
    const tokendecoded = this.getDecodedToken()
    if(!tokendecoded)
      return null
    return tokendecoded?.nameid
  }

  getUserName()
  {
    const tokendecoded = this.getDecodedToken()
    if(!tokendecoded)
      return null
    return tokendecoded?.unique_name
  }

  isLoggedIn() : boolean{
    const token = this.getToken()
    if(!token)
      return false
    const decoded = this.getDecodedToken()
    console.log(decoded)
    const currentTime = Math.floor(new Date().getTime() / 1000)
    return decoded?.exp > currentTime
  }
}
