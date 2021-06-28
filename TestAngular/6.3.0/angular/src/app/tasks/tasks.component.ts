import { AddOrEditTaskModelComponent } from './add-or-edit-task-model.component';
import { TaskListDto, TaskServiceProxy, TaskState } from '@shared/service-proxies/service-proxies';
import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { result } from 'lodash-es';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent extends AppComponentBase implements OnInit {
  tasks:TaskListDto[]=[];
  selectedState: TaskState;
  stateSelectedOptions=[
    {text: this.l('AllTasks'), value: undefined},
    {text: this.l('TaskState_Open'), value: TaskState._1},
    {text: this.l('TaskState_Close'), value: TaskState._0}
  ];
    @ViewChild('addOrEditTaskmodal') addOrEditTaskModal:AddOrEditTaskModelComponent;
  constructor(injector:Injector, private taskService: TaskServiceProxy) { 
    super(injector);
  }

  ngOnInit(): void {
   this.getTasks();
  }
  getTasks(){
    this.taskService.getAll(this.selectedState as any).subscribe(result =>{
      this.tasks= result.items;
      console.log("select=",this.selectedState);
      console.log("result=",result.items);
    })
  }

  getTaskLabel(task: TaskListDto){
    return task.state ===TaskState._1
          ?'label-success'
          :'label-default';
  }

  getTaskState(task:TaskListDto){
    switch(task.state){
      case TaskState._1:
        return this.l('TaskState_Open');
      case TaskState._0:
        return this.l('TaskState_Close');
      defult:
      return '';
    }
  }
  showTaskModal(){
    this.addOrEditTaskModal.show();
  }
 onTaskUpdated(task:TaskListDto){
   this.tasks.push(task);
   this.notify.success(this.l('SavedSuccessully'));
 }
}
