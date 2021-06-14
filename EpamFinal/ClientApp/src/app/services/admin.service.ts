import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})

export class AdminService {

  private baseApiUrl : string;
  private apiGetUsersUrl  : string;
  private apiDeleteUrl  : string;
  private apiGetAllUserFiles  : string;

  constructor(private httpClient: HttpClient) {
    this.baseApiUrl = 'https://localhost:44320';
    this.apiGetUsersUrl = this.baseApiUrl + '/Admin/AllUsers';
    this.apiDeleteUrl = this.baseApiUrl + '/Admin/DeleteUser';
    this.apiGetAllUserFiles = this.baseApiUrl + '/File/AllFiles';
   }

  public getUsers(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.apiGetUsersUrl);
  }

  public getFiles(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.apiGetAllUserFiles);
  }

  public deleteUser(userName: string): Observable<HttpEvent<Blob>> {
    return this.httpClient.request(new HttpRequest(
      'DELETE',
      `${this.apiDeleteUrl}?userName=${userName}`,
      null,
      {
        reportProgress: true,
      }));
  }
}
