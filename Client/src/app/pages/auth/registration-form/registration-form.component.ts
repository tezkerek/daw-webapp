import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { fromEvent, Observable } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss'],
})
export class RegistrationFormComponent {
  registrationForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  errorMessage?: string;

  constructor(private readonly router: Router, private readonly authService: AuthService) {
  }

  register(): void {
    const {email, password} = this.registrationForm.value as { email: string, password: string };
    this.authService.register(email, password).subscribe(
      success => {
        this.errorMessage = undefined;
        alert("Registration successful. Redirecting to login page.");
        this.router.navigate(['/auth/login']);
      },
      err => this.errorMessage = "Could not register with credentials",
    );
  }
}
