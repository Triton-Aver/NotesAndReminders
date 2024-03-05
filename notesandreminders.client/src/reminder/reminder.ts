import { Note } from "../note/note";

export class Reminder {
  constructor(
    public reminderId?: number,
    public description?: string,
    public deadLine?: Date,
    public note?: Note) { }
}
