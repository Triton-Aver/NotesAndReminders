import { Note } from "../note/note";
import { Tage } from "../tage/tage";

export class NoteTag {
  constructor(
    public noteId?: number,
    public note?: Note,
    public tagId?: number,    
    public tag?: Tage) { }
}
