import { Component,OnInit } from '@angular/core';
import { Router,RouterModule,RouterOutlet} from '@angular/router';
import { HttpClient,HttpHeaders} from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { S3Service } from '../../services/s3.service';
import { ProdusService } from '../../services/produs.service';
import { UserService } from '../../services/user.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-admin-panel',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterModule,RouterOutlet],
  providers: [ProdusService,UserService],
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.css'
})
export class AdminPanelComponent implements OnInit {
  produse="";
  infoUser="";
  username="";
  role="";
  constructor( private httpClient: HttpClient,private router:Router,private s3Service:S3Service,private produs:ProdusService,private user:UserService) { }
  ngOnInit(): void {
    this.infoUser=this.user.isLoggedIn();
    var aux=JSON.parse(this.infoUser);
    this.username=aux["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    this.role=aux["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  }
  deleteProdus(numeProdus: string): void {
    this.produs.getProdusByNume(numeProdus).subscribe(
      (response) => {
        if (response && response.id) {
          const produsId = response.id;
          this.produs.deleteProdusById(produsId).subscribe(
            () => {
              alert(`${response.nume} sters cu succes`);
            },
            (error) => {
              console.error(`Eroare: ${error}`);
            }
          );
        } else {
          alert(`${response.nume} nu exista.`);
        }
      },
      (error) => {
        console.error(`Nu s-a putut prelua produsl: ${error}`);
      }
    );
  }
  logout(){
    this.user.logout();
    this.router.navigate(['/login']);
  }
} 
