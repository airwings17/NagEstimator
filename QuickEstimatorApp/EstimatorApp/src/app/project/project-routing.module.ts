import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddEditProjectComponent } from './add-edit-project.component';
import { ProjectDashboardComponent } from './project-dashboard.component';

const routes: Routes = [  
             {path: '', component: ProjectDashboardComponent },
             {path: 'project/:id', component: AddEditProjectComponent },
             {path: 'sample', component: ProjectDashboardComponent }
          ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
