import { Pipe, PipeTransform } from '@angular/core';
import { WorkOrderDuration } from '../models/work-order.model';

@Pipe({
    name: 'sum'
})
export class SumPipe implements PipeTransform {
    transform(workOrders: WorkOrderDuration[], column: string): number {
        return workOrders
            .map(wo => wo.durations[column] || 0)
            .reduce((sum, current) => sum + current, 0);
    }
}