﻿using Medicard.Services.ViewModels.Doctor;

namespace Medicard.WebUI.Models
{
    public class ShowAllDoctorsViewModel
    {
        public IEnumerable<AllDoctorsViewModel> AllDoctors { get; set; }

        public PageViewModel PagingInfo { get; set; }
    }
}