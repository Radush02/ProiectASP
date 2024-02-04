import { Component,OnInit } from '@angular/core';
import { Router} from '@angular/router';
import { HttpClient} from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { S3Service } from '../services/s3.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})

export class DashboardComponent implements OnInit {

  produse: any[]=[];
  constructor( private httpClient: HttpClient,private router:Router,private s3Service:S3Service) { }
  apiKey="https://localhost:7259/api";
  ngOnInit(): void {
    this.httpClient.get(this.apiKey + "/Produs").subscribe(
      (response: any) => {
        this.produse = response;
        console.log(this.produse);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  getImageUrl(imageName: string): string {
    return this.s3Service.getObjectUrl('dawbucket', imageName + '.png');
  }
}