using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ViewModels.AccountViewModels
{
    public class InitialSettingsViewModel
    {
        public string UserName { get; set; }
        public string UserPic { get; set; }
        public int selectedBranchID { get; set; }
        public IList<SelectListItem> AvailableBranches { get; set; }

    }
}
