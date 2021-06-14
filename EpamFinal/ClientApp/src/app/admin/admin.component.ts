import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from '../services/admin.service';
import { FilesService } from '../services/files.service';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  public users: string[];
  public files: string[];
  userDetails;

  constructor(private service : AdminService,private fileService : FilesService , private userService : RegistrationService, private toastr: ToastrService) { }

  ngOnInit() {
    this.getUsers();
    this.getUser();
    this.getFiles();
  }
  getUsers() {
    this.service.getUsers().subscribe(
      data => {
        this.users = data;
      }
    );
  }
  public getFiles(){
    this.service.getFiles().subscribe(
      data => {
        this.files = data;
      }
    );
  }

  private checkUserName(userName : string){
    if(this.userDetails.userName === userName){
      return false;
    }
    return true;

  }
  public deleteUser(userName : string){
    if(this.checkUserName(userName) === true){
      this.service.deleteUser(userName).subscribe();
      this.removeElementFromArray(userName);
      return;
    }
    this.toastr.info("You can`t delete yourself")
  }

  public deleteFile(fileName : string) {
    this.fileService.deleteFile(fileName).subscribe();
    this.removeElementFromArray(fileName);
    return;
  }

  private removeElementFromArray(element: string) {
    this.users.forEach((value,index)=>{
        if(value==element) this.users.splice(index,1);
    });
  }

  public getUser() {
    this.userService.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      },
    );
  }

}
