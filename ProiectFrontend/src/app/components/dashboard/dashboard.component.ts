import { Component,OnInit } from '@angular/core';
import { Router} from '@angular/router';
import { HttpClient} from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { S3Service } from '../../services/s3.service';
import { ProdusService } from '../../services/produs.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  providers: [ProdusService,UserService],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})

export class DashboardComponent implements OnInit {

  produse: any[]=[];
  infoUser="";
  username="";
  constructor( private httpClient: HttpClient,private router:Router,private s3Service:S3Service,private produs:ProdusService,private user:UserService) { }
  ngOnInit(): void {
    this.produs.getAll().subscribe(
      (response: any) => {
        this.produse = response;
        console.log(this.produse);
      },
      (error: any) => {
        console.error(error);
      }
    );
    if(this.user.isLoggedIn()==""){
      this.router.navigate(['/login']);
    }
    else{
      this.infoUser=this.user.isLoggedIn();
      this.username=JSON.parse(this.infoUser)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
      
    }
  }
  
  logout(){
    this.user.logout();
    this.router.navigate(['/login']);
  }
  getImageUrl(imageName: string): string {
    return this.s3Service.getObjectUrl('dawbucket', imageName + '.png');
  }
}