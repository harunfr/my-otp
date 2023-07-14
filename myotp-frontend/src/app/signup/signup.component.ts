import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
})
export class SignupComponent {
  username: string = '';
  password: string = '';
  phone: string = '';
  email: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  onSignup() {
    const url = 'https://localhost:7273/Signup';
    const data = {
      username: this.username,
      password: this.password,
      phone: this.phone,
      email: this.email,
    };

    this.http.post(url, data).subscribe(
      (response) => {
        console.log('Signup successful');
        // Handle the response if needed

        // Yönlendirme yap
        this.router.navigate(['/login']);
      },
      (error) => {
        console.error('Signup failed');
        // Handle the error if needed
      }
    );
  }
}
