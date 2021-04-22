using Abp.Localization;
using Gosei.SimpleTaskApp.Tasks;
using Gosei.SimpleTaskApp.Tasks.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Web.Models.Tasks
{
    public class IndexViewModel
    {
        public TaskState? SelectedTaskState { get; set; }

        public List<SelectListItem> GetTasksStateSelectListItems(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = localizationManager.GetString(SimpleTaskAppConsts.LocalizationSourceName, $"AllTasks"),
                Value = "",
                Selected = SelectedTaskState == null
            }
        };

            list.AddRange(Enum.GetValues(typeof(TaskState))
                    .Cast<TaskState>()
                    .Select(state =>
                        new SelectListItem
                        {
                            Text = localizationManager.GetString(SimpleTaskAppConsts.LocalizationSourceName, $"TaskState_{state}"),
                            Value = state.ToString(),
                            Selected = state == SelectedTaskState
                        })
            );

            return list;
        }
        public List<SelectListItem> GetTasksState(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>();
            list.AddRange(Enum.GetValues(typeof(TaskState))
                .Cast<TaskState>()
                .Select(state =>
                new SelectListItem
                {
                    Text = localizationManager.GetString(SimpleTaskAppConsts.LocalizationSourceName, $"TaskState_{state}"),
                    Value = state.ToString(),
                    Selected = state == SelectedTaskState
                })
                ); 
            return list;
        }
        public IReadOnlyList<TaskListDto> Tasks { get; }
        public TaskListDto Task { get; }

        public IndexViewModel(IReadOnlyList<TaskListDto> tasks, TaskListDto task)
        {
            Tasks = tasks;
            Task = task;
        }
        //public IndexViewModel(IReadOnlyList<TaskListDto> tasks)
        //{
        //    Tasks = tasks;
        //    Task = task;
        //}

        public string GetTaskLabel(TaskListDto task)
        {
            switch (task.State)
            {
                case TaskState.Open:
                    return "label-success";
                default:
                    return "label-default";
            }
        }
    }
}
