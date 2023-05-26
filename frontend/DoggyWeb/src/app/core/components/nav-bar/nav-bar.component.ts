import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor() { }

  public isAuthenticated: boolean = true;

  public fullName: string = 'Ivan Shramko';

  public ngOnInit(): void {
  }

}
