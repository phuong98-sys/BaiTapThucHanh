﻿namespace Gosei.SimpleTaskApp.Web.Models.Common.Modals
{
    public class ModalHeaderViewModel
    {
        public string Title { get; set; }

        public ModalHeaderViewModel(string title)
        {
            Title = title;
        }
    }
}