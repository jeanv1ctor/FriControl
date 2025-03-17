import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultCadastroLayoutComponent } from './default-cadastro-layout.component';

describe('DefaultCadastroLayoutComponent', () => {
  let component: DefaultCadastroLayoutComponent;
  let fixture: ComponentFixture<DefaultCadastroLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DefaultCadastroLayoutComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DefaultCadastroLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
