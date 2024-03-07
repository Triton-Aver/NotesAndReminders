import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ReminderComponent } from './reminder.component';
import { Note } from '../note/note';

describe('ReminderComponent', () => {
  let component: ReminderComponent;
  let fixture: ComponentFixture<ReminderComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ReminderComponent],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ReminderComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the reminder', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve reminder from the server', () => {
    const mockReminder = [
      {
        reminderId: 0,
        deadLine: new Date('2021-10-02'),
        note: new Note()
      }
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/api/Reminder');
    expect(req.request.method).toEqual('GET');
    req.flush(mockReminder);

    expect(component.reminders).toEqual(mockReminder);

  });
});
