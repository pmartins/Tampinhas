using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tampinhas.Models
{
    public class ProjectProjectCommentViewModel
    {
        public Project Project { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}