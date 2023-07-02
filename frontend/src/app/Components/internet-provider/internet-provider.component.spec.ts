import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternetProviderComponent } from './internet-provider.component';

describe('InternetProviderComponent', () => {
  let component: InternetProviderComponent;
  let fixture: ComponentFixture<InternetProviderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InternetProviderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InternetProviderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
