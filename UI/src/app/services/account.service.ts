import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/user';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = 'https://localhost:5001/api/'
  CurrentUser = signal<User | null> (null)
  roles = computed(() => {
    const user = this.CurrentUser();
    if(user && user.token) {
      const role = JSON.parse(atob(user.token.split('.')[1])).role
      return Array.isArray(role) ? role : [role];
    }
    return [];
  })

  login(model:any) {
    return this.http.post<User>(this.baseUrl + 'auth/login',model).pipe(
      map(user =>{
        if(user) {
          this.setCurrentUser(user)
        }
      })
    )
  }

  setCurrentUser(user:User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.CurrentUser.set(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.CurrentUser.set(null);
  }
}
