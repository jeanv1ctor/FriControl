import { Component } from '@angular/core';
import { MenuComponent } from '../../components/menu/menu.component';
import { ButtonComponent } from '../../components/button/button.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table'


@Component({
  selector: 'app-item',
  standalone: true,
  imports: [
    MenuComponent,
    ButtonComponent,
    MatFormFieldModule,
    MatPaginatorModule,
    MatTableModule
  ],
  templateUrl: './item.component.html',
  styleUrl: './item.component.scss'
})
export class ItemComponent {
  //displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource:  any;

  applyFilter(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLocaleLowerCase();
  }
}
