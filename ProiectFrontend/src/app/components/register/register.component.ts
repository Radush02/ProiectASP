
import { Component,inject,OnInit } from '@angular/core';
import { RouterOutlet,Router} from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient,HttpClientModule} from '@angular/common/http';
import { FormBuilder,FormGroup,Validators,ReactiveFormsModule} from '@angular/forms';
import { UserService } from '../../services/user.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  imports: [CommonModule,RouterOutlet,HttpClientModule,ReactiveFormsModule],
  providers:[UserService],
  styleUrls: ['./register.component.css'],
  standalone:true
})
export class RegisterComponent {
  registerForm: FormGroup;
  errorMessage="";
  constructor(private http: HttpClient,private register:UserService,private router:Router,private fb:FormBuilder) { 
    this.registerForm=this.fb.group
      ({
        UserName: ['', Validators.required],
        Nume: ['', Validators.required],
        Email: ['', [Validators.required, Validators.email]],
        NrTelefon: ['', Validators.required],
        Oras: ['', Validators.required],
        Adresa: ['', Validators.required],
        Parola: ['', Validators.required]
      });

  }

  onSubmit() {
    this.register.register(this.registerForm.value).subscribe((response: any) => {
      this.router.navigate(['/login']);

    }, (error: any) => {
      console.error(error);
      console.log(this.registerForm.value)
      this.errorMessage = error.error;
    });
  }
}
