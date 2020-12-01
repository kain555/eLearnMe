import { AuthService } from 'src/app/core/service/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../../services/account.service'
import { DiscipleToken } from 'src/models/DiscipleToken';
@Component({ 
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
})
export class SigninComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  returnUrl: string;
  error = '';
  hide = true;
  model: any = {};
  loggedIn = false;
  user: DiscipleToken;
  constructor(
    private accountService: AccountService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {}
  ngOnInit() {
    this.setCurrentDisciple();
    this.loginForm = this.formBuilder.group({
      username: ['admin', Validators.required],
      password: ['admin', Validators.required],
    });
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login() {
      this.model = {"login": this.f.username.value, "password": this.f.password.value};
      this.accountService.login(this.model).subscribe(x => {
      }, error => {
        console.log(error);
      }); 
  }

  setCurrentDisciple() {
    const disciple: DiscipleToken = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentDisciple(disciple);
  }
  get f() {
    return this.loginForm.controls;
  }
  onSubmit() {
    this.login();
    this.submitted = true;
    this.error = '';
    this.model = {"login": this.f.username.value, "password": this.f.password.value};
    if (this.loginForm.invalid) {
      this.error = 'Username and Password not valid !';
      return;
    } else {
      this.authService
        .login(this.f.username.value,this.f.password.value)
        .subscribe(
          (res) => {
            const su = true;
            if (su) {
              this.router.navigate(['/dashboard/main']);
            } else {
              this.error = 'Invalid Login';
            }
          },
          (error) => {
            this.error = error;
            this.submitted = false;
          }
        );
    }
  }
}
