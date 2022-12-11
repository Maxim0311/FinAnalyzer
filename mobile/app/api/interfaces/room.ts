export interface IRoom {
  id: number;
  name: string;
  description: string;
}

export interface IRoomCreate {
  name: string;
  description?: string;
}
