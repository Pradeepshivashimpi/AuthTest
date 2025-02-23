import { Component, inject } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, RouterLink,],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);
  private router = inject(Router);
  model:any={}

  login(){
    this.accountService.login(this.model).subscribe({
      next : _ => {
         this.router.navigateByUrl('/products');
      },
      error: error => alert(error.error)
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
