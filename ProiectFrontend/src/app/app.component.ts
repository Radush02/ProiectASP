import { Component,inject,OnInit } from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient,HttpClientModule} from '@angular/common/http';
import { FormsModule, NgModel } from '@angular/forms';
import { ProdusComponent } from './produs/produs.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule,RouterOutlet,HttpClientModule,FormsModule,ProdusComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'ProiectFrontend';
}
