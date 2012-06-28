using System;
using System.Collections.Generic;
using Tampinhas.Models;

namespace Tampinhas.ViewModels
{
    public class ProjectIndexData {
        public IEnumerable<Project> Projects            { get; set; }
        public IEnumerable<Organization> Organization   { get; set; }
        public IEnumerable<Place> District              { get; set; }
        public IEnumerable<Place> County                { get; set; }
        public IEnumerable<Place> Locality              { get; set; }
    }
    
}