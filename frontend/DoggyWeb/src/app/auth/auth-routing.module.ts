import { LegalInfoComponent } from './components/shelter-register/legal-info/legal-info.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from 'src/app/auth/components/login/login.component';
import { RegisterComponent } from 'src/app/auth/components/register/register.component';
import { DescriptionComponent } from 'src/app/auth/components/shelter-register/description/description.component';
import { MainInfoComponent } from 'src/app/auth/components/shelter-register/main-info/main-info.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'shelter-register',
    component: MainInfoComponent
  },
  {
    path: 'shelter-register/description',
    component: DescriptionComponent
  },
  {
    path: 'shelter-register/legal',
    component: LegalInfoComponent
  },
  {
    path: '**',
    redirectTo: 'login'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
