import { Component } from '@angular/core';
import { EstimateService } from 'src/app/shared/estimate.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EstimatorApp';
  projects : Project[]=[]; 

  constructor ( private estimateService: EstimateService){};
  AddProject()
  {
    this.projects=[];    
    let project =new  Project();
    project.ProjectName="Caseta Wireless";
    project.Manager="Manvendra";

    this.projects.push(project); 
    project =new  Project();
    project.ProjectName="Lutron 2013 Migration";
    project.Manager="Abhai";

    this.projects.push(project); 
    this.estimateService.AddProject(this.projects).subscribe();
  }
}

export class PhasedEstimateDto 
{
  estimateVersion : EstimationVersionsHistories;
  versinDetailsPhased : VersionDetails_Phased[]=[];
  assumptions :Assumptions[]=[];
  inScope : InScopes[]=[]; 
  outScope: OutScopes[]=[]; 
}

export class Category
{
  Id:number;
  TaskCategory:string;
}
export class Assumptions
{
  Id:number;
  VersionID:number;
  Assumption:string;
}
export class EstimationVersionsHistories
{
  Id:number;
  ProjectId: number;
  EstimationType: string;
  VersionSummary: string;
  Estimates: number;
  Cost: number;
  CustomerSharedEstimates: number;
  CustomerSharedCost: number;
  EstimationDate: Date;
  PMEfforts: number;
  IsApproved: boolean;
  EstimatedBy: string;
  ReviewedBy: string;
  Created: string;
  Modified: string;
  CreatedBy: string;
  ModifiedBy: string;
}
export class InScopes
{
  Id:number;
  VersionID: number;
  InScpoeItem: string;
}
export class OutScopes
{
  Id:number;
  VersionID: number;
  OutScopeItes: string;
}
export class ProjectReleaseEfforts_Featured
{
  Id:number;
  VersionID: number;
  Task: string;
  TotalEfforts: number;
  TotalCost: number;
  Comments: string;
}
export class VersionDetails_Featured
{
  Id:number;
  VersionID: number;
  Task: string;
  SubTask: string;
  Time_Requirement: number;
  Time_Design: number;
  Time_UX: number;
  Time_Development: number;
  Time_Testing: number;
  Time_Deployment: number;
  TotalEfforts: number;
  TotalCost: number;
  Comments: string;
}
export class VersionDetails_Phased
{
  Id:number;
  VersionID: number;
  CategoryID: number;
  Task: string;
  SubTask: string;
  Time: number;
  NoOfItems: number;
  TotalEfforts: number;
  TotalCost: number;
  Comments: string;
}
export class Project {  
  Id:number;
  ProjectName: string;
  projectUrlName: string;
  Manager: string;
  CostPerhr: Number;
  Team: string;
  EmailLink: string;
  SketchLink: string;
  JiraLink: string;
  TechnicalApproachNeeded: boolean;
  EnvtSetupAndRampupNeeded: boolean;
  BrowserTestingNeeded: boolean;
  DeviceTestingNeeded: boolean;
  PerformanceTestingNeeded: boolean;
  AutomationTestingNeeded: boolean;
  RegressionTestingNeeded: boolean;
  ReleaseDocumentNeeded: boolean;
  AdminGuideNeeded: boolean;
  UserGuideNeeded: boolean;
  PMEffortsinPercentage: Number;
  UATSupportNeeded:boolean;
  WarrantySupportNeeded:boolean;
  Created: Date
  Modified: Date;
  CreatedBy: string;
  ModifiedBy: string;
}
