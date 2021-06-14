import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProgressStatus, ProgressStatusEnum } from '../progress-status.model';
import { FilesService } from '../services/files.service';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-file-manager',
  templateUrl: './file-manager.component.html',
  styleUrls: ['./file-manager.component.css']
})
export class FileManagerComponent implements OnInit {

  userDetails : Object;
  public files: string[];
  public fileInDownload: string;
  public percentage: number;
  public showProgress: boolean;
  public showDownloadError: boolean;
  public showUploadError: boolean;
  

  constructor(private service: RegistrationService, private fileService : FilesService, private router: Router) {
    
  }

  ngOnInit() {
    this.getUser();
  }
  public getFiles(userName : string){
    this.fileService.getPersonalFiles(userName).subscribe(
      data => {
        this.files = data;
      }
    );
  }
  public getUser() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
        this.getFiles(this.userDetails['userName'])
      },
      err => {
        console.log(err);
      },
    );
  }

  public deleteFile(fileName : string) {
    this.fileService.deleteFile(fileName).subscribe();
    this.removeElementFromArray(fileName);
  }

  private removeElementFromArray(element: string) {
    this.files.forEach((value,index)=>{
        if(value==element) this.files.splice(index,1);
    });
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  public downloadStatus(event: ProgressStatus) {
    switch (event.status) {
      case ProgressStatusEnum.START:
        this.showDownloadError = false;
        break;
      case ProgressStatusEnum.IN_PROGRESS:
        this.showProgress = true;
        this.percentage = event.percentage;
        break;
      case ProgressStatusEnum.COMPLETE:
        this.showProgress = false;
        break;
      case ProgressStatusEnum.ERROR:
        this.showProgress = false;
        this.showDownloadError = true;
        break;
    }
  }

  public uploadStatus(event: ProgressStatus) {
    switch (event.status) {
      case ProgressStatusEnum.START:
        this.showUploadError = false;
        break;
      case ProgressStatusEnum.IN_PROGRESS:
        this.showProgress = true;
        this.percentage = event.percentage;
        break;
      case ProgressStatusEnum.COMPLETE:
        this.showProgress = false;
        this.getFiles(this.userDetails['userName']);
        break;
      case ProgressStatusEnum.ERROR:
        this.showProgress = false;
        this.showUploadError = true;
        break;
    }
  }

}
