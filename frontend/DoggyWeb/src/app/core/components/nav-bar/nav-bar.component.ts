import { AuthManagerService } from 'src/app/auth/services/auth-manager.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(
    private authManagerService: AuthManagerService
  ) { }

  public isAuthenticated: boolean = false;

  public fullName: string = 'Ivan Shramko';

  public ngOnInit(): void {
   this.authManagerService.isAuthenticated.subscribe(res => {
    this.isAuthenticated = res;
   })
  }

}
