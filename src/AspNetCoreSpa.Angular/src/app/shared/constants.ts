export class Constants {
  public static apiRoot = "http://localhost:5000/api";
  public static clientRoot = "http://localhost:8080";
  public static idpAuthority = "https://localhost:8090";
  //public static clientRoot = "http://localhost:4200";
  //public static idpAuthority = "https://localhost:5001";
  public static clientId = "angular-client";
  public static scope = "openid profile backApi";
  public static signInRedirectCallback = "signin-callback";
  public static signOutRedirectCallback = "signout-callback";
}
