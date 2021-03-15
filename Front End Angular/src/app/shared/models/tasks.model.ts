export interface ITasks {
  id: number;
  node: string;
  createdAt: string;
  endDate: string;
  isDone: boolean;
  categoryId: number;
  completedAt: string;
  doneNote?: string;
}
