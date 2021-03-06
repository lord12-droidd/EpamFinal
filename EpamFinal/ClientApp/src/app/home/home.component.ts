import { Component, OnInit } from '@angular/core';
import { ProgressStatus, ProgressStatusEnum } from '../progress-status.model';
import { FilesService } from '../services/files.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  userDetails;
  public files: string[];
  public percentage: number;
  public showProgress: boolean;
  public showDownloadError: boolean;
  public showUploadError: boolean;

  constructor(private fileService : FilesService) { }

  ngOnInit() {
    this.getFiles();
  }
  getFiles() {
    this.fileService.getFiles().subscribe(
      data => {
        this.files = data;
      }
    );
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
}
