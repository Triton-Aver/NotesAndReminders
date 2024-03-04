import { NoteTag } from "../models/NoteTags"
export class Tage {
  constructor(
    public tagId?: number,
    public tagName?: string,
    public noteTags?: NoteTag[]) { }
}
