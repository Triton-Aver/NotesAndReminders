import { Reminder } from "../reminder/reminder";
import { Tage } from "../tage/tage";

export class Note {
  constructor(
    public noteId?: number,
    public header?: string,
    public description?: string,
    public dateCreate?: Date,
    public tags?: Tage[],
    public reminderNote?: Reminder ) { }
}
