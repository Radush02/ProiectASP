import { Component,inject,OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient,HttpClientModule} from '@angular/common/http';
import { FormsModule, NgModel } from '@angular/forms';

@Component({
  selector: 'produs',
  templateUrl: `./produs.component.html`,
  standalone: true,
  imports: [CommonModule,RouterOutlet,HttpClientModule,FormsModule]
})
export class ProdusComponent implements OnInit {

}
