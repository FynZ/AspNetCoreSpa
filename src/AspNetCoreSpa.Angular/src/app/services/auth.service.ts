import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import {Constants} from "../shared/constants";
import {Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userManager: UserManager;
  private user!: User | null;

  private loginChangedSubject = new Subject<boolean>();
  public loginChanged = this.loginChangedSubject.asObservable();

  private get idpSettings() : UserManagerSettings {
    return {
      authority: Constants.idpAuthority,
      client_id: Constants.clientId,
      redirect_uri: `${Constants.clientRoot}/${Constants.signInRedirectCallback}`,
      scope: Constants.scope,
      response_type: "code",
      post_logout_redirect_uri: `${Constants.clientRoot}/${Constants.signOutRedirectCallback}`
    }
  }
  constructor() {
    this.userManager = new UserManager(this.idpSettings);
  }

  public login = () => {
    return this.userManager.signinRedirect();
  }

  public isAuthenticated = (): Promise<boolean> => {
    return this.userManager.getUser()
      .then(user => {
        if(this.user !== user){
          this.loginChangedSubject.next(this.checkUser(user));
        }
        this.user = user;
        return this.checkUser(user);
      })
  }

  public finishLogin = (): Promise<User> => {
    return this.userManager.signinRedirectCallback()
      .then(user => {
        console.log(user);
        this.user = user;
        this.loginChangedSubject.next(this.checkUser(user));
        return user;
      })
  }

  public logout = () => {
    this.userManager.signoutRedirect().finally();
  }
  public finishLogout = () => {
    this.user = null;
    return this.userManager.signoutRedirectCallback();
  }

  private checkUser = (user : User | null): boolean => {
    return !!user && !user.expired;
  }
}
