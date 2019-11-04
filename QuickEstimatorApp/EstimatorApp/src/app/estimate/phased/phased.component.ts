import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, NgForm, FormArray, FormControl } from '@angular/forms';
import { EstimateService } from 'src/app/shared/estimate.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { elementAt } from 'rxjs/operators';
import { stringify } from 'querystring';
import { EstimationVersionsHistories, VersionDetails_Phased, Assumptions, InScopes, OutScopes, PhasedEstimateDto } from 'src/app/app.component';
@Component({
  selector: 'app-phased',
  templateUrl: './phased.component.html',
  styleUrls: ['./phased.component.css']
})


export class PhasedComponent implements OnInit {

  phasedEstimatedDto = new PhasedEstimateDto();
  estimateVersion = new EstimationVersionsHistories();
  versinDetailsPhased: VersionDetails_Phased[] = [];
  assumptions: Assumptions[] = [];
  inScope: InScopes[] = [];
  outScope: OutScopes[] = [];


  panelOpenState = false;
  phasedEstimateForm: FormGroup;
  requirementCategories: FormControl;
  time: FormControl
  noOfItems: FormControl;
  Reqsum: number = 0;
  controlArray: [];
  sub: any;
  projID: number = -1;
  constructor(private fb: FormBuilder, private estimateService: EstimateService, private route: ActivatedRoute, private router: Router) {
    this.route.queryParams.subscribe((params: Params) => {
      console.log(params);
    });
  }
  ngOnInit() {

    this.route.paramMap.subscribe(
      params => {
        this.projID = +params.get('projId');
      });


    this.phasedEstimateForm = this.fb.group({
      versionSummarry: '',
      estimatedBy: '',
      reviewedBy: '',
      estimationDate: '',
      requirementArray: this.fb.array([this.build_RequirementBlock()]),
      devArray: this.fb.array([this.build_RequirementBlock()]),
      deploymentArray: this.fb.array([this.build_RequirementBlock()]),
      qaArray: this.fb.array([this.build_RequirementBlock()]),
      uatArray: this.fb.array([this.build_RequirementBlock()]),
      ktArray: this.fb.array([this.build_RequirementBlock()])
    });
  }

  get requirement(): FormArray {
    return <FormArray>this.phasedEstimateForm.get("requirementArray");
  }
  get dev(): FormArray {
    return <FormArray>this.phasedEstimateForm.get("devArray");
  }
  get deployment(): FormArray {
    return <FormArray>this.phasedEstimateForm.get("deploymentArray");
  }
  get qa(): FormArray {
    return <FormArray>this.phasedEstimateForm.get("qaArray");
  }
  get uat(): FormArray {
    return <FormArray>this.phasedEstimateForm.get("uatArray");
  }
  get kt(): FormArray {
    return <FormArray>this.phasedEstimateForm.get("ktArray");
  }



  /*
      ngOnInit() {      
        this.phasedEstimateForm =  this.fb.group(
          {
            catArray : this.fb.array([
              this.fb.group({
                category: '',
              }),          
              this.fb.array(            
                [              
                  this.fb.group({
                    Task: [''],
                    SubTask: [''],
                    Time:[''],
                    NoOfItems:['1'],
                    Total:[''],
                    Comment:['']     
                  })
              ])
            ])
            
          }                  
        )       
    
   */


  calculateLineTotal(currentFormGroup: FormGroup): number {
    return 5;
  }
  addRequirementBlock(currentBlock: FormArray): void {
    currentBlock.push(this.build_RequirementBlock());
  }

  removeRequirementBlock(currentBlock: FormArray, i: number): void {
    if (confirm("Are you sure to delete current bolck")) {
      currentBlock.removeAt(i);
    }
  }
  calcluateOverAllEstimateInPD(): string {
    let sum = this.calcluateOverAllEstimate();
    let strSum: string;
    if (sum > 0) {
      strSum = "(" + sum + " pds)";
    }
    return strSum;
  }
  calcluateOverAllEstimate(): number {
    let sum = 0;
    this.requirement.controls.forEach(element => {
      sum = sum + (element.value.Time * element.value.NoOfItems);
    });
    this.dev.controls.forEach(element => {
      sum = sum + (element.value.Time * element.value.NoOfItems);
    });
    this.deployment.controls.forEach(element => {
      sum = sum + (element.value.Time * element.value.NoOfItems);
    });
    this.qa.controls.forEach(element => {
      sum = sum + (element.value.Time * element.value.NoOfItems);
    });
    this.uat.controls.forEach(element => {
      sum = sum + (element.value.Time * element.value.NoOfItems);
    });
    this.kt.controls.forEach(element => {
      sum = sum + (element.value.Time * element.value.NoOfItems);
    });
    return sum;
  }
  calculateEstimateTotal(currentBlock: FormArray): number {
    let sum = 0;
    currentBlock.controls.forEach(element => {
      sum = sum + (element.value.Time * element.value.NoOfItems);
    });
    return sum;
  }


  SaveEfforts(): void {
    this.FillDTO();
    this.estimateService.AddPhasedEstimates(this.phasedEstimatedDto).subscribe(
      data => {
        console.log('success');
      }
    );
  }

  FillDTO(): void {
    this.estimateVersion.ProjectId = this.projID;
    this.estimateVersion.EstimationType = "Phased";
    this.estimateVersion.VersionSummary = this.phasedEstimateForm.controls.versionSummarry.value;
    this.estimateVersion.Estimates = this.calcluateOverAllEstimate();
    this.estimateVersion.Cost = this.calcluateOverAllEstimate() * 28.5;
    this.estimateVersion.EstimationDate = this.phasedEstimateForm.controls.estimationDate.value;
    //this.estimateVersion.PMEfforts = 
    this.estimateVersion.IsApproved = true;
    this.estimateVersion.EstimatedBy = this.phasedEstimateForm.controls.estimatedBy.value;
    this.estimateVersion.ReviewedBy = this.phasedEstimateForm.controls.reviewedBy.value;
    this.estimateVersion.Created = this.phasedEstimateForm.controls.estimatedBy.value;
    this.estimateVersion.Modified = this.phasedEstimateForm.controls.estimatedBy.value;

    this.phasedEstimatedDto.estimateVersion = this.estimateVersion;

    let requirementDetails: VersionDetails_Phased;
    for (let i = 0; i < this.requirement.controls.length; i++) {
      if (this.requirement.controls[i].value.Time > 0 || this.requirement.controls[i].value.Comment.trim().length > 0) {
        requirementDetails = new VersionDetails_Phased();
        requirementDetails.CategoryID = 1;
        requirementDetails.Task = this.requirement.controls[i].value.Task;
        requirementDetails.SubTask = this.requirement.controls[i].value.SubTask;
        requirementDetails.Time = this.requirement.controls[i].value.Time;
        requirementDetails.NoOfItems = this.requirement.controls[i].value.NoOfItems;
        requirementDetails.Comments = this.requirement.controls[i].value.Comment;
        this.phasedEstimatedDto.versinDetailsPhased.push(requirementDetails);
      }
    }

    for (let i = 0; i < this.dev.controls.length; i++) {
      if (this.dev.controls[i].value.Time > 0 || this.dev.controls[i].value.Comment.trim().length > 0) {
        requirementDetails = new VersionDetails_Phased();
        requirementDetails.CategoryID = 2;
        requirementDetails.Task = this.dev.controls[i].value.Task;
        requirementDetails.SubTask = this.dev.controls[i].value.SubTask;
        requirementDetails.Time = this.dev.controls[i].value.Time;
        requirementDetails.NoOfItems = this.dev.controls[i].value.NoOfItems;
        requirementDetails.Comments = this.dev.controls[i].value.Comment;
        this.phasedEstimatedDto.versinDetailsPhased.push(requirementDetails);
      }
    }
    for (let i = 0; i < this.deployment.controls.length; i++) {
      if (this.deployment.controls[i].value.Time > 0 || this.deployment.controls[i].value.Comment.trim().length > 0) {
        requirementDetails = new VersionDetails_Phased();
        requirementDetails.CategoryID = 3;
        requirementDetails.Task = this.deployment.controls[i].value.Task;
        requirementDetails.SubTask = this.deployment.controls[i].value.SubTask;
        requirementDetails.Time = this.deployment.controls[i].value.Time;
        requirementDetails.NoOfItems = this.deployment.controls[i].value.NoOfItems;
        requirementDetails.Comments = this.deployment.controls[i].value.Comment;
        this.phasedEstimatedDto.versinDetailsPhased.push(requirementDetails);
      }
    }

    for (let i = 0; i < this.qa.controls.length; i++) {
      if (this.qa.controls[i].value.Time > 0 || this.qa.controls[i].value.Comment.trim().length > 0) {
        requirementDetails = new VersionDetails_Phased();
        requirementDetails.CategoryID = 4;
        requirementDetails.Task = this.qa.controls[i].value.Task;
        requirementDetails.SubTask = this.qa.controls[i].value.SubTask;
        requirementDetails.Time = this.qa.controls[i].value.Time;
        requirementDetails.NoOfItems = this.qa.controls[i].value.NoOfItems;
        requirementDetails.Comments = this.qa.controls[i].value.Comment;
        this.phasedEstimatedDto.versinDetailsPhased.push(requirementDetails);
      }
    }

    for (let i = 0; i < this.uat.controls.length; i++) {
      if (this.uat.controls[i].value.Time > 0 || this.uat.controls[i].value.Comment.trim().length > 0) {
        requirementDetails = new VersionDetails_Phased();
        requirementDetails.CategoryID = 7;
        requirementDetails.Task = this.uat.controls[i].value.Task;
        requirementDetails.SubTask = this.uat.controls[i].value.SubTask;
        requirementDetails.Time = this.uat.controls[i].value.Time;
        requirementDetails.NoOfItems = this.uat.controls[i].value.NoOfItems;
        requirementDetails.Comments = this.uat.controls[i].value.Comment;
        this.phasedEstimatedDto.versinDetailsPhased.push(requirementDetails);
      }
    }
    for (let i = 0; i < this.kt.controls.length; i++) {
      if (this.kt.controls[i].value.Time > 0 || this.kt.controls[i].value.Comment.trim().length > 0) {
        requirementDetails = new VersionDetails_Phased();
        requirementDetails.CategoryID = 8;
        requirementDetails.Task = this.kt.controls[i].value.Task;
        requirementDetails.SubTask = this.kt.controls[i].value.SubTask;
        requirementDetails.Time = this.kt.controls[i].value.Time;
        requirementDetails.NoOfItems = this.kt.controls[i].value.NoOfItems;
        requirementDetails.Comments = this.kt.controls[i].value.Comment;
        this.phasedEstimatedDto.versinDetailsPhased.push(requirementDetails);
      }
    }
    let localassumption = new Assumptions();
    localassumption.Assumption = "Sample Assumption 1";
    this.assumptions.push(localassumption);

    localassumption = new Assumptions();
    localassumption.Assumption = "Sample Assumption 2";
    this.assumptions.push(localassumption);
    this.phasedEstimatedDto.assumptions = this.assumptions;

    let localInScope = new InScopes();
    localInScope.InScpoeItem = "Sample in Scopoe 1";
    this.inScope.push(localInScope);

    localInScope = new InScopes();
    localInScope.InScpoeItem = "Sample in Scopoe 2";
    this.inScope.push(localInScope);
    this.phasedEstimatedDto.inScope = this.inScope;

    let localOutScope = new OutScopes();
    localOutScope.OutScopeItes = "Sample Outscope 1";
    this.outScope.push(localOutScope);

    localOutScope = new OutScopes();
    localOutScope.OutScopeItes = "Sample Outscope 2";
    this.outScope.push(localOutScope);

    this.phasedEstimatedDto.outScope = this.outScope;


  }



  build_RequirementBlock(): FormGroup {
    return this.fb.group({
      Task: [''],
      SubTask: [''],
      Time: ['', [Validators.required, Validators.pattern("^[0-9]+(.[0-9]{0,2})*$")]],
      NoOfItems: ['1', [Validators.required, Validators.pattern("^[0-9]+(.[0-9]{0,2})*$")]],
      Total: [''],
      Comment: ['']
    })
  }
}
