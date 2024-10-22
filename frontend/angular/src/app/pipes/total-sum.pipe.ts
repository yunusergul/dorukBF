import { Pipe, PipeTransform } from '@angular/core';
import { WorkOrderDuration } from '../models/work-order.model';

@Pipe({
    name: 'totalSum'
})
export class TotalSumPipe implements PipeTransform {
    transform(workOrders: WorkOrderDuration[]): number {
        return workOrders
            .map(wo => wo.total)
            .reduce((sum, current) => sum + current, 0);
    }
}