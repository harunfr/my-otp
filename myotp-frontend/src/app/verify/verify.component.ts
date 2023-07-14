import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-verify',
  templateUrl: './verify.component.html',
  styleUrls: ['./verify.component.css'],
})
export class VerifyComponent implements OnInit {
  userId: string = '';
  otp: string = '';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.userId = params.get('userId') || '';
    });
  }

  onSubmit(): void {
    // İstek gövdesi
    const body = {
      id: this.userId,
      otp: this.otp,
    };

    // İstek gönderme
    this.http.post('https://localhost:7273/Login/verify', body).subscribe(
      (response: any) => {
        console.log(response);

        // Başarılı yanıt işleme
        if (response && response.message === 'OTP doğrulandı') {
          console.log('Verification successful');
          this.router.navigate(['/']); // Ana sayfaya yönlendir
        } else {
          console.log('OTP verification failed');
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
