import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { fromEvent, Observable } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss'],
})
export class LoginFormComponent {
  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  errorMessage?: string;

  constructor(private readonly router: Router, private readonly authService: AuthService) {
  }

  login(): void {
    const {email, password} = this.loginForm.value as { email: string, password: string };
    this.authService.login(email, password).subscribe(
      success => {
        this.errorMessage = undefined;
        this.router.navigate(['/']);
      },
      err => this.errorMessage = "Could not log in with credentials",
    );
  }
}
