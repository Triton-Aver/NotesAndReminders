import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TageComponent } from './tage.component';

describe('TageComponent', () => {
  let component: TageComponent;
  let fixture: ComponentFixture<TageComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TageComponent],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TageComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create Tage', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve Tage from the server', () => {
    const mockTags = [
      {
        tagId: 0,
        tagName: 'test',
        notes: []
      },
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('https://localhost:7156/api/Tage');
    expect(req.request.method).toEqual('GET');
    req.flush(mockTags);

    expect(component.tages).toEqual(mockTags);
  });
});
