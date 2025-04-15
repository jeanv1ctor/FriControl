import { Component,AfterViewInit, ViewChild} from '@angular/core';
import { MenuComponent } from '../../components/menu/menu.component';
import { ButtonComponent } from '../../components/button/button.component';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Item } from '../../models/Item';
import { MatDialog } from '@angular/material/dialog';
import { CadastroItemComponent } from '../../components/cadastro-item/cadastro-item.component';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [
    ButtonComponent,
    MenuComponent,
    ButtonComponent,
    MatFormFieldModule,
    MatPaginatorModule,
    MatTableModule,
    MatPaginator,
    MatSort,
    MatSortModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './item.component.html',
  styleUrl: './item.component.scss'
})
export class ItemComponent {
  
  displayedColumns: string[] = ['patrimonio', 'nomeItem', 'descricaoItem', 'marcaItem', 'valorItem', 'acao'];
  itens:  MatTableDataSource<Item>
  dialog: MatDialog;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(){
    this.itens = new MatTableDataSource<Item>([{
      patrimonio: 1265342,
      nomeItem: 'mouse',
      descricaoItem: 'teste',
      marcaItem: 'multilaser',
      valorItem: 15.90,
      categoriaId: 1
    },
    {
      patrimonio: 54352345,
      nomeItem: 'impressora',
      descricaoItem: 'impressora multifuncional',
      marcaItem: 'EPSON',
      valorItem: 600.70,
      categoriaId: 1
    }
  ]);
  }


  ngAfterViewInit() {
    this.itens.paginator = this.paginator;
    this.itens.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.itens.filter = filterValue.trim().toLowerCase();

    if (this.itens.paginator) {
      this.itens.paginator.firstPage();
    }
  }

  updateItem(item: Item){}

  
  deleteItem(item: Item){}

  
  openDialog(item: Item | null){
    const dialogRef = this.dialog.open(CadastroItemComponent, {
      data: item != null ? 
      item:{
        patrimonio: 0,
        nomeItem: '',
        descricaoItem: ''
      },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
     // this.animal = result;
    });
  }
}


