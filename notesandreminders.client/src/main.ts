import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { NoteModule } from './note/note.module';
import { TageModule } from './tage/tage.module';
import { ReminderModule } from './reminder/reminder.module';


platformBrowserDynamic().bootstrapModule(NoteModule)
  .catch(err => console.error(err));
platformBrowserDynamic().bootstrapModule(TageModule)
  .catch(err => console.error(err));
platformBrowserDynamic().bootstrapModule(ReminderModule)
  .catch(err => console.error(err));

