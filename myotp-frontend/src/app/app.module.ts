import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; // FormsModule ekleyin

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { VerifyComponent } from './verify/verify.component';

@NgModule({
  declarations: [AppComponent, SignupComponent, LoginComponent, VerifyComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, // FormsModule'ü imports'e ekleyin
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
