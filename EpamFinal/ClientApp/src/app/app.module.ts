import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { ToastrModule } from 'ngx-toastr';
import { AdminComponent } from './admin/admin.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { DownloadComponent } from './download/download.component';
import { FileManagerComponent } from './file-manager/file-manager.component';
import { UploadComponent } from './upload/upload.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RegistrationComponent,
    LoginComponent,
    AdminComponent,
    ForbiddenComponent,
    DownloadComponent,
    FileManagerComponent,
    UploadComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FileManagerComponent,canActivate: [AuthGuard] },
      { path: 'registration', component : RegistrationComponent},
      { path: 'login', component : LoginComponent},
      { path: 'forbidden', component : ForbiddenComponent},
      { path: 'admin',component : AdminComponent ,canActivate:[AuthGuard],data :{permittedRoles:['Admin']}}
    ])
  ],
  providers: [RegistrationComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
