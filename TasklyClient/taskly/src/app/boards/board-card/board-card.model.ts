import { Task } from "../../tasks/task/task.model";

export class BoardCard {
  public boardId: number;
  public name: string;
  public description: string;
  public taskNumber: number;
  public visible: boolean;
  public pinned: boolean;
  public tasks: Array<Task>;
}
