import { Component,inject,OnInit } from '@angular/core';
import { RouterOutlet,Router} from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient,HttpClientModule} from '@angular/common/http';
import { FormBuilder,FormGroup,Validators,ReactiveFormsModule} from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  imports: [CommonModule,RouterOutlet,HttpClientModule,ReactiveFormsModule],
  providers:[UserService],
  styleUrls: ['./login.component.css'], 
  standalone: true
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  errorMessage="";
  constructor(private fb: FormBuilder, private httpClient: HttpClient,private router:Router,private loginService:UserService) {
    this.loginForm=this.fb.group({
      userName: ['',Validators.required],
      parola: ['',[Validators.required,Validators.minLength(8)]],
      remember: [false,Validators.required]
    });
  }

  login() {
    this.loginService.login(this.loginForm.value).subscribe((response: any) => {
      localStorage.setItem('token', response.token);
      this.errorMessage='Conectat';
      this.router.navigate(['/dashboard']);

    }, (error: any) => {
      console.error(error);
      this.errorMessage = error.error;
    });
  }
  register(){
    console.log('aaaaa');
    this.router.navigate(['/register']);
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