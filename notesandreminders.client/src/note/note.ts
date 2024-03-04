import { NoteTag } from "../models/NoteTags";

export class Note {
  constructor(
    public noteId?: number,
    public header?: string,
    public description?: string,
    public dateCreate?: Date,
    public noteTags?: NoteTag[]) { }
}
