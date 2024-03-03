import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { NoteModule } from './note/note.module';
import { TageModule } from './tage/tage.module';

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
platformBrowserDynamic().bootstrapModule(NoteModule)
  .catch(err => console.error(err));
platformBrowserDynamic().bootstrapModule(TageModule)
  .catch(err => console.error(err));
