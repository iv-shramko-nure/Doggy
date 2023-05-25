import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from '@angular/forms';
import { MainInfoComponent } from './components/shelter-register/main-info/main-info.component';
import { DescriptionComponent } from './components/shelter-register/description/description.component';
import { LegalInfoComponent } from './components/shelter-register/legal-info/legal-info.component';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    MainInfoComponent,
    DescriptionComponent,
    LegalInfoComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ]
})
export class AuthModule { }
