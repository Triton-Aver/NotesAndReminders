import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { NoteModule } from './note/note.module';

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
platformBrowserDynamic().bootstrapModule(NoteModule)
  .catch(err => console.error(err));
