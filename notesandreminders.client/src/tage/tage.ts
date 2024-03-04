import { Note } from "../note/note";

export class Tage {
  constructor(
    public tagId?: number,
    public tagName?: string,
    public notes?: Note[]) { }
}
