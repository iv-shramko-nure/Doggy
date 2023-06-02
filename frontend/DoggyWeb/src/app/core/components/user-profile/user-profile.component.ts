import { AuthManagerService } from 'src/app/auth/services/auth-manager.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  constructor(
    private router: Router,
    private authManagerService: AuthManagerService
  ) { }

  ngOnInit(): void {
  }

  logout() {
    this.authManagerService.logout().subscribe(res => {
      if (res) {
        this.router.navigate(['auth']);
      }
    })
  }

}
