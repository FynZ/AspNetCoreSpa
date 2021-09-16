import { Component, OnInit } from '@angular/core';
import {AuthService} from "../services/auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public isUserAuthenticated: boolean = false;
  constructor(private authService: AuthService) { }

  ngOnInit(): void {

    this.authService.isAuthenticated()
      .then(userAuthenticated => {
        this.isUserAuthenticated = userAuthenticated;
      })

    this.authService.loginChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
      })
  }

  public login = () => {
    this.authService.login().finally();
  }

  public logout = () => {
    this.authService.logout();
  }
}
