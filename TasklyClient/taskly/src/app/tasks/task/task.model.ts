export class Task {
  public taskId: number;
  public statusId: number;
  public priorityId: number;
  public boardId: number;
  public name: string;
  public description: string;
  public startDateTime: Date;
  public dueDate: Date;
  public endDate: Date;
  public note: string;
  public attachmentLink: string;
  public timeAmount: number;
  public taskCheckLists: any;
}
