// login.component.ts
import { Component,inject,OnInit } from '@angular/core';
import { RouterOutlet,Router} from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient,HttpClientModule} from '@angular/common/http';
import { FormBuilder,FormGroup,Validators,ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  imports: [CommonModule,RouterOutlet,HttpClientModule,ReactiveFormsModule],
  styleUrls: ['./login.component.css'], 
  standalone: true
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  apiKey="https://localhost:7259/api";
  errorMessage="";
  constructor(private fb: FormBuilder, private httpClient: HttpClient,private router:Router) {
    this.loginForm=this.fb.group({
      userName: ['',Validators.required],
      parola: ['',[Validators.required,Validators.minLength(8)]],
      remember: [false,Validators.required]
    });
  }

  login() {
    this.httpClient.post<any>(this.apiKey+"/User/login", this.loginForm.value).subscribe((response: any) => {
      localStorage.setItem('token', response.token);
      this.errorMessage='Conectat';
      this.router.navigate(['/dashboard']);

    }, (error: any) => {
      console.error(error);
      this.errorMessage = error.error;
    });
  }
  
  ngOnInit(){
    this.loginForm=this.fb.group({
      userName: ['',Validators.required],
      parola: ['',[Validators.required,Validators.minLength(8)]],
      remember: [false,Validators.required]
    });
    setTimeout(() => {
      if (localStorage.getItem('token')) {
        this.router.navigate(['/dashboard']);
      }
    });
  }
}
export default LoginComponent;