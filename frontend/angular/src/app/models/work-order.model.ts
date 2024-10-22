export interface WorkOrderDuration {
    orderNumber: string;
    durations: { [key: string]: number };
    total: number;
}