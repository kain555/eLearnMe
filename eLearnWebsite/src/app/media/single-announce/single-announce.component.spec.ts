import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleAnnounceComponent } from './single-announce.component';

describe('SingleAnnounceComponent', () => {
  let component: SingleAnnounceComponent;
  let fixture: ComponentFixture<SingleAnnounceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SingleAnnounceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleAnnounceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
