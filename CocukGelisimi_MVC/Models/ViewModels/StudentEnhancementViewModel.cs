using CocukGelisimi_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CocukGelisimi_MVC.Models.ViewModels
{
    public class StudentEnhancementViewModel
    {
        public Table_Student Student { get; set; }
        public Table_Cognitive_Enhancement Enhancement { get; set; }
        public List<Table_CognitiveContent> Contents { get; set; }
    }
}