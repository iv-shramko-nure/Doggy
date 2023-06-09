import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MainInfoComponent } from 'src/app/auth/components/shelter-register/main-info/main-info.component';
import { DescriptionComponent } from 'src/app/auth/components/shelter-register/description/description.component';
import { LegalInfoComponent } from 'src/app/auth/components/shelter-register/legal-info/legal-info.component';
import { SharedModule } from 'src/app/shared/shared.module';


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
    ReactiveFormsModule,
    SharedModule
  ]
})
export class AuthModule { }
