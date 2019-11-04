import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectRoutingModule } from './project-routing.module';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AddEditProjectComponent } from './add-edit-project.component';
import { ProjectDashboardComponent } from './project-dashboard.component';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDividerModule} from '@angular/material/divider';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatRadioModule} from '@angular/material/radio';
import {MatInputModule} from '@angular/material';
import { MatPaginatorModule } from '@angular/material';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
@NgModule({
  declarations: [AddEditProjectComponent,ProjectDashboardComponent],
  imports: [
    CommonModule,
    ProjectRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatDividerModule,
    MatCheckboxModule,
    MatRadioModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressSpinnerModule
    
  ]
})
export class ProjectModule { }
