import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegistrationService } from './registration.service';

@Injectable({
  providedIn: 'root'
})
export class FilesService {
  private baseApiUrl: string;
  private apiDownloadUrl: string;
  private apiUploadUrl: string;
  private apiFileUrl: string;
  private apiPersonalFilesUrl : string;

  constructor(private httpClient: HttpClient, private service: RegistrationService) {
    this.baseApiUrl = 'https://localhost:44320';
    this.apiDownloadUrl = this.baseApiUrl + '/File/Download';
    this.apiUploadUrl = this.baseApiUrl + '/File/Upload';
    this.apiFileUrl = this.baseApiUrl + '/File/Files';
    this.apiPersonalFilesUrl = this.baseApiUrl + '/File/PersonalFiles';
  }

  public downloadFile(file: string): Observable<HttpEvent<Blob>> {
    return this.httpClient.request(new HttpRequest(
      'GET',
      `${this.apiDownloadUrl}?file=${file}`,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }));
  }

  public uploadFile(file: Blob, isPrivate : boolean, userName : string): Observable<HttpEvent<void>> {
    const formData = new FormData();
    formData.append('file', file);
    
    //
    return this.httpClient.request(new HttpRequest(
      'POST',
      `${this.apiUploadUrl}?privacy=${isPrivate}&userName=${userName}`,
      formData,
      {
        reportProgress: true
      }));
  }

  public getFiles(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.apiFileUrl);
  }
  public getPersonalFiles(userInfo : any): Observable<string[]> {
    console.log(userInfo);
    return this.httpClient.get<string[]>(`${this.apiPersonalFilesUrl}?userName=${userInfo}`);
  }
}
