import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NoteComponent } from './note.component';
import { Reminder } from '../reminder/reminder';

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

  afterEach(() => {
    httpMock.verify();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve Note from the server', () => {
    const mockNotes = [
      {
        noteId: 0,
        header: 'Test',
        description: 'Test',
        dateCreate: new Date(2013, 0, 32),
        tags: [],
        reminderNote: new Reminder()
      }
    ];


    const req = httpMock.expectOne('/api/Note');
    expect(req.request.method).toEqual('GET');
    req.flush(mockNotes);

    expect(component.notes).toEqual(mockNotes);
  });
});
