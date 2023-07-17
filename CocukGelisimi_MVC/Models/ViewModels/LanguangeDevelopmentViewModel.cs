using CocukGelisimi_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CocukGelisimi_MVC.Models.ViewModels
{
    public class LanguangeDevelopmentViewModel
    {
        public Table_Student Student {  get; set; }
        public Table_Language_Development Language { get; set; }
        public List<Table_LanguageContent> Contents { get; set; }
        public List<Table_Language_Development> Languagelist { get; set; }
    }
}