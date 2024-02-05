import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { HttpClient } from '@angular/common/http';
import { Router ,RouterModule,RouterOutlet} from '@angular/router';
import { CommonModule } from '@angular/common';
import { ConvertirePipe } from '../pipes/convertire.pipe';
@Component({
  selector: 'app-info',
  standalone: true,
  imports: [CommonModule,RouterModule,RouterOutlet,ConvertirePipe],
  templateUrl: './info.component.html',
  styleUrl: './info.component.css'
})
export class InfoComponent implements OnInit {
  info:any={};
  constructor( private httpClient: HttpClient,private router:Router,private user:UserService) { }
  ngOnInit(){
    const infoUser=this.user.isLoggedIn();
    var aux=JSON.parse(infoUser);
    this.info['user']=aux["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    this.info['nume']=aux["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    this.info['email']=aux["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
    this.info['nrTelefon']=aux["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone"];
    this.info['role']=aux["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    this.info['data_conectare']=aux["nbf"];
  }
  logout(){
    this.user.logout();
    this.router.navigate(['/login']);
  }
}