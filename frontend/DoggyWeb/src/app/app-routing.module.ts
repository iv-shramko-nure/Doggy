import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from 'src/app/core/components/home-page/home-page.component';
import { ShelterSearchComponent } from 'src/app/shelters/components/shelter-search/shelter-search.component';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('../app/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'shelters',
    component: ShelterSearchComponent
  },
  {
    path: '',
    loadChildren: () => import('../app/core/core-routing.module').then(m => m.CoreRoutingModule)
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
