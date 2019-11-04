import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormBuilder, FormGroup, Validators ,FormsModule,NgForm } from '@angular/forms'; 
import { Project } from '../app.component';
import { EstimateService } from 'src/app/shared/estimate.service';
import { Observable, of } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-add-edit-project',
  templateUrl: './add-edit-project.component.html',
  styleUrls: ['./add-edit-project.component.css']
})
export class AddEditProjectComponent implements OnInit {
  pageTitle= "Add Edit Project";
  projectTypes: string[] = ['Web', 'Web-Fix'];
  projectForm: FormGroup;
  project: Project=new Project();
  projects : Project[]=[];
  sub: any;
  isLoading: boolean;
  constructor(
    private fb: FormBuilder ,private estimateService: EstimateService,
    private route: ActivatedRoute,private router:Router )    
    { }

  
  ngOnInit() {
    this.projectForm = this.fb.group({
      ProjectName: ['', [Validators.required, Validators.minLength(3)]],
      projectUrlName: [''],
      CostPerhr:['35'],
      Team:[''],

      TechnicalApproachNeeded: [true],EnvtSetupAndRampupNeeded: [false],
      BrowserTestingNeeded: [true],DeviceTestingNeeded: [true],RegressionTestingNeeded: [false],
      PerformanceTestingNeeded: [''],AutomationTestingNeeded: [false],
      UATSupportNeeded: [true],WarrantySupportNeeded: [false],
      ReleaseDocumentNeeded: [true],
      AdminGuideNeeded: [false],UserGuideNeeded: [false],
          
      PMEffortsinPercentage: ['15%'],
      EmailLink:[''],
      SketchLink:[''],
      JiraLink:['']
    }); 
    this.sub =this.route.paramMap.subscribe(
      params=>{
        const id=+params.get('id');
        this.getProduct(id);
      });
    
  }


  
  
  getProduct(id: any):void
  {
    console.log(id);
    this.isLoading =true;
    this.estimateService.getProject(id).subscribe(
      (project: Project) => this.displayProject(project)
    );
  }

  displayProject(project:Project):void{
    console.log(project);
    
    this.project=project;
    if(project.Id==0)
    {
      this.pageTitle="Add Project";
    }
    else
    {
      if(this.projectForm)
      {
      this.projectForm.reset();
      }
      this.pageTitle="Edit Project";
      this.projectForm.patchValue({
          id:this.project.Id,
          ProjectName:this.project.ProjectName,
          projectUrlName: this.project.projectUrlName,
          CostPerhr:this.project.CostPerhr, 
          Team:this.project.Team,          
          TechnicalApproachNeeded:this.project.TechnicalApproachNeeded,
          EnvtSetupAndRampupNeeded: this.project.EnvtSetupAndRampupNeeded,          
          BrowserTestingNeeded: this.project.BrowserTestingNeeded,
          DeviceTestingNeeded: this.project.DeviceTestingNeeded,
          RegressionTestingNeeded: this.project.RegressionTestingNeeded,  
          PerformanceTestingNeeded: this.project.PerformanceTestingNeeded,
          AutomationTestingNeeded: this.project.AutomationTestingNeeded,
          UATSupportNeeded:this.project.UATSupportNeeded,
          WarrantySupportNeeded:this.project.WarrantySupportNeeded,
          ReleaseDocumentNeeded: this.project.ReleaseDocumentNeeded,
          AdminGuideNeeded: this.project.AdminGuideNeeded,
          UserGuideNeeded:this.project.UserGuideNeeded,              
          PMEffortsinPercentage: this.project.PMEffortsinPercentage,
          EmailLink:this.project.EmailLink,
          SketchLink:this.project.SketchLink,
          JiraLink:this.project.JiraLink
        });
    }
    this.isLoading =false;
  }

   // Executed When Form Is Submitted  
   onFormSubmit(form:NgForm)  
   {  
    this.isLoading =true;
     this.FillProjectDto(form);
     this.estimateService.AddProject(this.projects).subscribe(
       data=>{  console.log('success');
       this.isLoading =false;
      }    
     );
   } 
  FillProjectDto(form:NgForm)
  {
    this.projects=[]; 
    let project =new  Project();
    
    
    project.Manager="Manvendra";
    project.Modified=new Date();
    project.ModifiedBy="Harsh";
    if(this.project.Id==0)
    {
      project.Id=null;
      project.CreatedBy="Harsh";
      project.Created= new Date();
    }
    else
    {
      project.Id=this.project.Id;
      project.ModifiedBy="Harsh";
      project.Modified= new Date();
    }
  
    const p= {...project,...this.projectForm.value};
  
    this.projects.push(p); 
    //this.AddProject(form);   
  }

}
