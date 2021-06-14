import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProgressStatus, ProgressStatusEnum } from '../progress-status.model';
import { FilesService } from '../services/files.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent{

  @Input() public disabled: boolean;
  @Input() public fileName: string;
  @Output() public downloadStatus: EventEmitter<ProgressStatus>;

  constructor(private service: FilesService) {
    this.downloadStatus = new EventEmitter<ProgressStatus>();
  }

  public delete() {
    this.service.deleteFile(this.fileName).subscribe();
  }

}
