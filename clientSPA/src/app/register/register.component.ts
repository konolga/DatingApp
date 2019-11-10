import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { User } from '../_models/user';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
@Output() cancelRegister = new EventEmitter();
user: User= {
  id: null,
  email: '',
  name: '',
  lastName: '',
  password: '',
  confirmPassword: ''
};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {

  }

  register() {
    this.authService.register(this.user).subscribe(() =>{
      console.log(this.user)
      this.alertify.success('registration successful');
    }, error => {
      console.log(error.error)
      this.alertify.error(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

  onSubmit(registerForm: FormGroup) {
    if (registerForm.valid) {
      this.register();
    } else {
      this.validateAllFormFields(registerForm);
    }
  }

  validateAllFormFields(registerForm: FormGroup)  {
    (Object as any).values(registerForm.controls).forEach(control => {
      control.markAsDirty();
      if (control.controls) {
        this.validateAllFormFields(control);
      }
    });
  }

}
