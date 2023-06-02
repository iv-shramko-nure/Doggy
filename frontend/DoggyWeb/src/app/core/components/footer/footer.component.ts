import { Component, OnInit } from '@angular/core';
import { AuthManagerService } from 'src/app/auth/services/auth-manager.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor(
    private authManagerService: AuthManagerService
  ) { }

  public isAuthenticated: boolean = false;

  public ngOnInit(): void {
   this.authManagerService.isAuthenticated.subscribe(res => {
    this.isAuthenticated = res;
   })
  }

}
