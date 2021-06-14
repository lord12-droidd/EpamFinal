import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validator, Validators} from "@angular/forms"
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  
  constructor(public service: RegistrationService, private toastr: ToastrService) { }

  
  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.toastr.success('New user created!', 'Registration successful.');
        }
        else if (!res.succeeded) {
          this.toastr.error("This Username or Email is already taken",'Registration failed.');
        }
      },
      err => {
        console.log(err);
      }
    );
  }


}
