import { Component } from '@angular/core';
import { MenuComponent } from '../../components/menu/menu.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MenuComponent,
    MatProgressSpinnerModule

  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}
