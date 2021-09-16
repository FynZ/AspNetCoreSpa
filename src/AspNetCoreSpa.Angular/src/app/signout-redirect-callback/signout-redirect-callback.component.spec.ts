import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignoutRedirectCallbackComponent } from './signout-redirect-callback.component';

describe('SignoutRedirectCallbackComponent', () => {
  let component: SignoutRedirectCallbackComponent;
  let fixture: ComponentFixture<SignoutRedirectCallbackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignoutRedirectCallbackComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignoutRedirectCallbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
