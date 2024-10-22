import { Component, OnInit } from '@angular/core';
import { WorkOrderService } from '../../services/work-order.service';
import { WorkOrderDuration } from '../../models/work-order.model';

@Component({
    selector: 'app-work-order-table',
    templateUrl: './work-order-table.component.html',
    styleUrls: ['./work-order-table.component.css']
})
export class WorkOrderTableComponent implements OnInit {
    workOrders: WorkOrderDuration[] = [];
    columns: string[] = [];
    loading = false;
    error = '';

    constructor(private workOrderService: WorkOrderService) {}

    ngOnInit() {
        this.loadWorkOrders();
    }

    loadWorkOrders() {
        this.loading = true;
        this.workOrderService.getWorkOrderDurations().subscribe({
            next: (data) => {
                this.workOrders = data;
                this.updateColumns();
                this.loading = false;
            },
            error: (err) => {
                this.error = 'Veri yüklenirken hata oluştu';
                this.loading = false;
            }
        });
    }

    private updateColumns() {
        const reasonSet = new Set<string>();
        this.workOrders.forEach(wo => {
            Object.keys(wo.durations).forEach(reason => {
                reasonSet.add(reason);
            });
        });
        this.columns = Array.from(reasonSet).sort();
    }

    getDuration(workOrder: WorkOrderDuration, reason: string): number {
        return workOrder.durations[reason] || 0;
    }
}