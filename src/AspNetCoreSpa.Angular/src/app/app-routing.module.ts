import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component'
import { LoginComponent } from './login/login.component'
import {SigninRedirectCallbackComponent} from "./signin-redirect-callback/signin-redirect-callback.component";
import {SignoutRedirectCallbackComponent} from "./signout-redirect-callback/signout-redirect-callback.component";
import {Constants} from "./shared/constants";
import {TestComponent} from "./test/test.component";

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent},
  { path: 'login', component: LoginComponent },
  { path: 'test', component: TestComponent },
  { path: Constants.signInRedirectCallback, component: SigninRedirectCallbackComponent },
  { path: Constants.signOutRedirectCallback, component: SignoutRedirectCallbackComponent },
  { path: '**', redirectTo: 'home'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
