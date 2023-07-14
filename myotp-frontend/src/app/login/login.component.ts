import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private router: Router, private http: HttpClient) {}

  onSubmit(): void {
    // İstek gövdesi
    const body = {
      username: this.username,
      password: this.password,
    };

    // İstek başlıkları
    const headers = new HttpHeaders()
      .set('accept', '*/*')
      .set('Content-Type', 'application/json');

    // İstek gönderme
    this.http.post('https://localhost:7273/Login', body, { headers }).subscribe(
      (response: any) => {
        // Başarılı yanıt işleme
        if (response && response.message === 'E-posta ile OTP gönderildi') {
          // Yanıtta success true ise, doğru kullanıcı bilgileri girilmiştir.
          // Kullanıcıyı /verify adresine yönlendir ve userId'i aktar
          console.log('aa');

          console.log(response);

          this.router.navigate(['/verify'], {
            state: { userId: response.userId },
          });
        } else {
          // Yanıtta success false ise, hatalı kullanıcı bilgileri girilmiştir.
          console.log('Login failed');
        }
      },
      (error) => {
        // Hata durumunda işlemler
        console.error(error);
      }
    );
  }
}
