import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoteComponent } from '../note/note.component';
//import { TagsComponent } from './tags/tags.component';
//import { RemindersComponent } from './reminders/reminders.component';

const routes: Routes = [
  { path: 'note', component: NoteComponent },
  //{ path: 'tags', component: TagsComponent },
  //{ path: 'reminders', component: RemindersComponent },
  //{ path: '', redirectTo: '/notes', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
