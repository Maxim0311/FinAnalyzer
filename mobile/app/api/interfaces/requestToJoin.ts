import { IPerson } from "./auth";

export interface IRequestToJoin {
  id: number;
  roomId: number;
  person: IPerson;
  dateTime: string;
}
