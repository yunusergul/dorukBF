import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkOrderDuration } from '../models/work-order.model';

@Injectable({
    providedIn: 'root'
})
export class WorkOrderService {
    private apiUrl = '/api/workorder/durations';

    constructor(private http: HttpClient) { }

    getWorkOrderDurations(): Observable<WorkOrderDuration[]> {
        return this.http.get<WorkOrderDuration[]>(this.apiUrl);
    }
}