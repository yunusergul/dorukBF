import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { WorkOrderTableComponent } from './components/work-order-table/work-order-table.component';
import { SumPipe } from './pipes/sum.pipe';
import { TotalSumPipe } from './pipes/total-sum.pipe';

@NgModule({
    declarations: [
        AppComponent,
        WorkOrderTableComponent,
        SumPipe,
        TotalSumPipe
    ],
    imports: [
        BrowserModule,
        HttpClientModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }