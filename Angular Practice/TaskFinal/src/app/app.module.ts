import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Http,HttpModule,Headers } from "@angular/http";
import { FormsModule } from "@angular/forms";

import { AppComponent } from './app.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { UserFormComponent } from './components/user-form/user-form.component';
import { UsersTableComponent } from './components/users-table/users-table.component';

import { UserService } from "./services/user.service";

@NgModule({
  declarations: [
    AppComponent,
    UserDashboardComponent,
    UserFormComponent,
    UsersTableComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
