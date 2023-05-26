import { PublishedPetsComponent } from './components/user-profile/profile-tabs/published-pets/published-pets.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomePageComponent } from "src/app/core/components/home-page/home-page.component";
import { AccountSecurityComponent } from 'src/app/core/components/user-profile/profile-tabs/account-security/account-security.component';
import { LikedPetsComponent } from 'src/app/core/components/user-profile/profile-tabs/liked-pets/liked-pets.component';
import { PersonalInfoComponent } from "src/app/core/components/user-profile/profile-tabs/personal-info/personal-info.component";
import { PostNewPetComponent } from 'src/app/core/components/user-profile/profile-tabs/post-new-pet/post-new-pet.component';
import { UserProfileComponent } from "src/app/core/components/user-profile/user-profile.component";

const routes: Routes = [
  {
    path: 'profile',
    component: UserProfileComponent,
    children: [
      {
        path: 'info',
        component: PersonalInfoComponent
      },
      {
        path: 'published-pets',
        component: PublishedPetsComponent
      },
      {
        path: 'security',
        component: AccountSecurityComponent
      },
      {
        path: 'liked-pets',
        component: LikedPetsComponent
      },
      {
        path: 'post-pet',
        component: PostNewPetComponent
      },
      {
        path: '**',
        redirectTo: 'info'
      }
    ]
  },
  {
    path: '',
    component: HomePageComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule { }
