import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './components/home-page/home-page.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { RouterModule } from '@angular/router';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { CoreRoutingModule } from 'src/app/core/core-routing.module';
import { PersonalInfoComponent } from './components/user-profile/profile-tabs/personal-info/personal-info.component';
import { PublishedPetsComponent } from './components/user-profile/profile-tabs/published-pets/published-pets.component';
import { AccountSecurityComponent } from './components/user-profile/profile-tabs/account-security/account-security.component';
import { LikedPetsComponent } from './components/user-profile/profile-tabs/liked-pets/liked-pets.component';
import { PostNewPetComponent } from './components/user-profile/profile-tabs/post-new-pet/post-new-pet.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FileUploadComponent } from 'src/app/shared/components/file-upload/file-upload.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [
    HomePageComponent,
    NavBarComponent,
    FooterComponent,
    UserProfileComponent,
    PersonalInfoComponent,
    PublishedPetsComponent,
    AccountSecurityComponent,
    LikedPetsComponent,
    PostNewPetComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    CoreRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ],
  exports: [
    NavBarComponent,
    FooterComponent
  ]
})
export class CoreModule { }
