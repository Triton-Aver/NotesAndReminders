import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NoteComponent } from './note.component';

describe('NoteComponent', () => {
  let component: NoteComponent;
  let fixture: ComponentFixture<NoteComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NoteComponent],
      imports: [HttpClientTestingModule]
    }).compileComponents();

    fixture = TestBed.createComponent(NoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve weather forecasts from the server', () => {
    const mockNotes = [
      { NoteId: 0, Header: 'Test', Description: 'Test', DateCreate: new Date('2021-10-01') }
    ];


    const req = httpMock.expectOne('/note');
    expect(req.request.method).toEqual('GET');
    req.flush(mockNotes);

    expect(component.notes).toEqual(mockNotes);
  });
});